using NativeWebSocket;

namespace Utils
{
    public class WebSocketHelper
    {
        public static WebSocket GetWebSocket()
        {
            return new WebSocket("wss://websockettelepresence.azurewebsites.net");
        }
    }
}