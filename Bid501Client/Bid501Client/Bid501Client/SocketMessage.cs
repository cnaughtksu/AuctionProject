using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
namespace Bid501Client
{
    class SocketMessage
    {
        private string name;

        SocketMessage(string name, int port)
        {
            this.name = name;
        }

        public void SendMessage(string message)
        {

        }
    }
}
