using System;
using System.Collections.Generic;
using Bid501Server.Database;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using WebSocketSharp;
using System.Windows.Forms;

namespace Bid501Client
{
    public delegate void NewBid();
    public delegate string LoadClient();
    public delegate void FinishedAuction();
    public delegate void Observer(List<AuctionProduct> products);
    class AuctionController
    {

        private Database database;
        private WebSocket ws;
        private List<AuctionProduct> auctionProducts;
        public Observer TriggerObserver;
        private List<DateTime> AuctionTimes;
        private string owner;
        private NewBid newbid;
        private FinishedAuction finishedAuction;
        private LoadClient loadClient;
        public AuctionController(NewBid newBid,FinishedAuction finished, LoadClient load)
        {
            auctionProducts = new List<AuctionProduct>();
            AuctionTimes = new List<DateTime>();
            newbid = newBid;
            loadClient = load;
            owner = loadClient();
            finishedAuction = finished;
            ws = new WebSocket("ws://192.168.0.18:8001/ServerMessage");
            ws.OnMessage += (sender, e) => loadProduct(e.Data);
            ws.Connect();
        }

        public List<AuctionProduct> InitializeAuction()
        {
            //Connect to actual database for real implementation
            //TEST
            /*string productFile = "products.json";
            string clientFile = "clients.json";
            using (StreamReader r = new StreamReader("products.json"))
            {
                string json = r.ReadToEnd();
                auctionProducts = JsonSerializer.Deserialize<List<AuctionProduct>>(json);
            }
            return auctionProducts;*/

            List<AuctionProduct> testProducts = new List<AuctionProduct>();
           

            return auctionProducts;
        }
        public void AddObserver(Observer obv)
        {
            TriggerObserver = obv;
        }

        public void loadProduct(string product)
        {
            if (product != null)
            {
                string[] temp = product.Split(',');
               
                if (temp.Length==3)
                {
                    auctionProducts.Add(new AuctionProduct(temp[0], Int32.Parse(temp[1]),0,temp[2],null));
                    // AuctionTimes.Add(Convert.ToDateTime(temp[3]));
                    //test
                    AuctionTimes.Add(DateTime.Now.AddHours(2));
                }
                else if (temp.Length == 1)
                {
                    MessageBox.Show(product);
                }
                else
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
                   
                }
                newbid();
            }
        }
        public void TimerTick()
        {

        }

        public void RefreshBid()
        {
            //Refresh bid in view if bid is for current product from delegate
        }

        public void RefreshProducts()
        {
            if (TriggerObserver != null)
                TriggerObserver(auctionProducts);
            //Update products list from delegate
        }

        public void BidHandle(AuctionProduct product, Transaction bid)
        {
            product.NumberOfBids++;
            ws.Send(product.Name + "," + bid.Amount + "," + product.NumberOfBids+","+owner);

            //int count = 0;
           /* foreach (var item in auctionProducts)
            {
                if (String.Compare(item.Name, product.Name) == 0)
                {
                    auctionProducts[count].MinimumBid = bid.
                    break;
                }
                count++;
            }*/
            //Update bid with new bid from the server
        }
        public void handleTimer()
        {
            int count = 0;
            foreach(var item in auctionProducts)
            {
                if (String.Compare(DateTime.Now.ToString("HH:mm:ss"),item.AuctionEndTime)==0)
                {
                    finishedAuction();
                    ws.Send(auctionProducts[count].Name + " AuctionEnded: Winner " + auctionProducts[count].Owner);
                    //FinalSaleHandle(auctionProducts[count], new Transaction(auctionProducts[count].MinimumBid, TransactionType.Buy));
                    break;
                }
                count++;
            }
        }
        public void FinalSaleHandle(AuctionProduct product, Transaction sale)
        {
            //Update products list with final sale from the server
        }
    }
}
