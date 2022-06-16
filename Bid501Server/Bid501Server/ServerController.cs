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
    public delegate void Observer(List<Database.AuctionProduct> products, List<Database.Client> clients);
    public delegate Database.Client NewClient(string str);
    public class ServerController
    {
        private string clientFile;
        private string productFile;
        private List<Database.AuctionProduct> auctionProducts;
        private List<Database.Client> clients;
        private List<Observer> observers;
        private WebSocket ws;
        public Observer TriggerObserver;
        public ServerController()
        {
            auctionProducts = new List<Database.AuctionProduct>();
            clients = new List<Database.Client>();
            ws = new WebSocket("ws://127.0.0.1:8001/ServerMessage");
            ws.OnMessage += (sender, e) => EditProduct(e.Data);
            ws.Connect();
        }
        public void AddObserver(Observer obv)
        {
            TriggerObserver = obv;
        }
        public List<Database.AuctionProduct> InitializeProducts()
        {
            auctionProducts.Add(new Database.AuctionProduct("Car",200,0, DateTime.Now.AddMinutes(1).ToString("HH:mm:ss"),null));
            auctionProducts.Add(new Database.AuctionProduct("Chair", 50, 0, DateTime.Now.AddHours(2).ToString("HH:mm:ss"), null));
            auctionProducts.Add(new Database.AuctionProduct("Doll", 1, 0, DateTime.Now.AddHours(2).ToString("HH:mm:ss"), null));
            string jsonString = JsonSerializer.Serialize(auctionProducts);
            File.WriteAllText("products.json", jsonString);
            using (StreamReader r = new StreamReader("products.json"))
            {
                string json = r.ReadToEnd();
                auctionProducts = JsonSerializer.Deserialize<List<Database.AuctionProduct>>(json);
                
            }
            

            return auctionProducts;
        }
        public void EditProduct(string product)
        {
            if (product != null)
            {
                string[] temp = product.Split(',');
                if (temp.Length > 3)
                {
                    int count = 0;
                    foreach (var item in auctionProducts)
                    {
                        if (String.Compare(item.Name, temp[0]) == 0)
                        {
                            auctionProducts[count].MinimumBid = Int32.Parse(temp[1]);
                            auctionProducts[count].NumberOfBids = Int32.Parse(temp[2]);
                            auctionProducts[count].Owner = temp[3];
                            break;
                        }
                        count++;
                    }
                    string jsonString = JsonSerializer.Serialize(auctionProducts);
                    File.WriteAllText("products.json", jsonString);
                } 
            }
        }
        public List<Database.Client> InitializeClients()
        {
            using (StreamReader r = new StreamReader("clients.json"))
            {
                string json = r.ReadToEnd();
                clients = JsonSerializer.Deserialize<List<Database.Client>>(json);
            }
            return clients;
        }
        public void AddProduct(Database.AuctionProduct auctionProduct)
        {

            auctionProducts.Add(auctionProduct);
            string jsonString = JsonSerializer.Serialize(auctionProducts);
            File.WriteAllText("products.json", jsonString);
            TriggerObserver(auctionProducts,clients);
            ws.Send(auctionProduct.Name + "," + auctionProduct.MinimumBid+","+auctionProduct.NumberOfBids+","+auctionProduct.AuctionEndTime);
            
        }
        public List<Database.AuctionProduct> UpdateView()
        {
            return auctionProducts;
        }
        public List<Database.Client> UpdateClients(Database.Client client)
        {
            clients.Add(client);
            return clients;
        }
        public void OpenAddProduct()
        {
            NewProduct newProduct = this.AddProduct;
            AddProductView addProduct = new AddProductView(newProduct);
            addProduct.Show();
        }
    }
   
}
