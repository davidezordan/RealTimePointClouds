using NativeWebSocket;
using UnityEngine;
using Utils;

public class ConnectAndSendEventsWebSockets : MonoBehaviour
{
    WebSocket websocket;
    
    void Start()
    {
        InitialiseWebSockets();
    }
    
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket?.DispatchMessageQueue();
#endif
    }
    
    void InitialiseWebSockets()
    {
        if (!DeviceHelper.IsRunningOnIphoneDevice())
        {
            Utils.Logger.Info("*** ConnectAndSendEventsWebSockets: Not running on iPhone device. Websockets sender not initialised.");
            return;
        }

        Utils.Logger.Info("*** ConnectAndSendEventsWebSockets: Running on device. Initialising socket connection");

        websocket = WebSocketHelper.GetWebSocket();

        websocket.OnOpen += () =>
        {
            Utils.Logger.Info("*** ConnectAndSendEventsWebSockets: Connection open!");
        };

        websocket.OnError += (e) =>
        {
            Utils.Logger.Info("*** ConnectAndSendEventsWebSockets: Websocket error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Utils.Logger.Info("*** ConnectAndSendEventsWebSockets: Connection closed!");
        };

        // waiting for messages
        websocket.Connect();
    }

    private async void OnApplicationQuit()
    {
        if (websocket != null)
            await websocket.Close();
    }
    
    public void SendSampleEvent(Vector3[] vertices, Color[] colors)
    {
        if (!DeviceHelper.IsRunningOnIphoneDevice())
        {
            return;
        }
        
        SendMessages(vertices, colors);
    }

    private long numMessage;
    
    private void SendMessages(Vector3[] vertices, Color[] colors)
    {
        // Only send 1 message every 10 to avoid network congestion
        numMessage++;
        
        if (numMessage == long.MaxValue)
            numMessage = 0;
        
        if (numMessage % 10 != 0)
            return;

        Utils.Logger.Info($"*** Send Sample Event called. Vertices: {vertices?.Length} - Colors: {colors?.Length}");

        if (vertices == null || colors == null)
            return;
        
        if (vertices.Length == 0 || colors.Length == 0)
        {
            return;
        }
        
        var result = VerticesColorHandler.GeneratePayload(vertices, colors);

        if (websocket?.State != WebSocketState.Open) return;
        
        Utils.Logger.Info($"*** Send websocket called. Vertices: {vertices?.Length} - Colors: {colors?.Length}");
        websocket?.Send(result);
    }
}
