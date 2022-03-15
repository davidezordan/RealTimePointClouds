using System;
using NativeWebSocket;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

public class ConnectAndReceiveEventsWebSockets : MonoBehaviour
{
    WebSocket _websocket;

    [FormerlySerializedAs("m_visualizer")] [SerializeField]
    Visualizer mVisualizer;
    
    void Start()
    {
        InitialiseWebSockets();
    }

    private float[] _lastReceivedFrame;

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        _websocket?.DispatchMessageQueue();
#endif
        
        ProcessMessageQueue();
    }
    
    private void ProcessMessageQueue()
    {
        if (_lastReceivedFrame == null || _lastReceivedFrame.Length == 0) return;
        
        var vertices = VerticesColorsHandler.GetVertices(_lastReceivedFrame);
        var colors = VerticesColorsHandler.GetColors(_lastReceivedFrame);

        if (mVisualizer)
        {
            mVisualizer.UpdateMeshInfo(vertices, colors);
        }
    }

    void InitialiseWebSockets()
    {
        Utils.Logger.Info($"*** ConnectAndReceiveEventsWebSockets: Initialising sockets.");
        
        _websocket = WebSocketHelper.GetWebSocket();

        _websocket.OnOpen += () =>
        {
            Utils.Logger.Info("*** ConnectAndReceiveEventsWebSockets: Connection open!");
        };
        
        _websocket.OnError += (e) =>
        {
            Utils.Logger.Info("*** ConnectAndReceiveEventsWebSockets: Websocket error! " + e);
        };
        
        _websocket.OnClose += (e) =>
        {
            Utils.Logger.Info("*** ConnectAndReceiveEventsWebSockets: Connection closed!");
        };

        _websocket.OnMessage += (receivedMessage) =>
        {
            if (receivedMessage.Length == 0)
                return;
            
            // Extract the frame from the received message and uncompress it.
            var compressedFrame = CLZF2.Decompress(receivedMessage);
            
            // Transform the received frame to a flot-array containing information about
            // vertices and colors.
            _lastReceivedFrame ??= new float[compressedFrame.Length / 4];
            Buffer.BlockCopy(compressedFrame, 0, _lastReceivedFrame, 
                0, compressedFrame.Length);
            
            // Add here information for OVR metric tools for data collection.
            var debugStringOvrTool = $"Message length: {receivedMessage.Length} - {DateTime.Now}";
        };

        // Waiting for messages
        _websocket.Connect();
    }

    private async void OnApplicationQuit()
    {
        if (_websocket != null)
            await _websocket.Close();
    } 
}