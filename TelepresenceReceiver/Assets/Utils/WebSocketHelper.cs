using NativeWebSocket;

namespace Utils
{
    public class WebSocketHelper
    {
        public static WebSocket GetWebSocket()
        {
            // Modify with custom endpoint here.
            return new WebSocket("ws://websockettelepresence.azurewebsites.net");
        }
    }
}