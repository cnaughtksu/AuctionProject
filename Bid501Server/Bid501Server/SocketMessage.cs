using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace Bid501Server
{
    public class SocketMessage: WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data;

            
        }

        private string clientFile;
        private List<Database.Client> clients;
        protected override void OnOpen()
        {
            clientFile = "clients.json";
            using (StreamReader r = new StreamReader("clients.json"))
            {
                string json = r.ReadToEnd();
                clients = JsonSerializer.Deserialize<List<Database.Client>>(json);
            }
            foreach (var client in clients)
            {
                Sessions.Broadcast(client.ClientType+","+client.Name+","+client.Password);
            }
        }
    }
}
