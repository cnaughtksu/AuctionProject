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
    public class ServerMessage  : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data;
            Sessions.Broadcast(msg);

        }

        private string clientFile;
        private List<Database.AuctionProduct> products;
        protected override void OnOpen()
        {
            using (StreamReader r = new StreamReader("products.json"))
            { 
                string json = r.ReadToEnd();
                products = JsonSerializer.Deserialize<List<Database.AuctionProduct>>(json);
            }
            foreach (var product in products)
            {
                Sessions.Broadcast(product.Name + "," + product.MinimumBid+","+product.AuctionEndTime);
            }
        }
       
    }
}
