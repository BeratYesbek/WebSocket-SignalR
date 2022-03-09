using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace WebSocketTest.Middleware
{
    public class WebSocketServerConnectionManager
    {
        private ConcurrentDictionary<string,WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public ConcurrentDictionary<string,WebSocket>  GetAllSockets()
        {
            return _sockets;
        }

        public string AddSocket(WebSocket webSocket)
        {
            string ConnID = Guid.NewGuid().ToString();
            _sockets.TryAdd(ConnID, webSocket);
            Console.WriteLine("Connection Added: " + ConnID);

            return ConnID;
        }
    }
}