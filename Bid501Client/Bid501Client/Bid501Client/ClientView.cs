using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501Server.Database;

namespace Bid501Client
{
    public delegate void BidHandler(AuctionProduct product, Transaction bid);
    public delegate void FinalSaleHandler(AuctionProduct product, Transaction sale);
    public delegate void Timer();
    public delegate List<AuctionProduct> InitAuction();

    public partial class ClientView : Form
    {
        private InitAuction initAuction;
        private BidHandler bidHandler;
        private FinalSaleHandler finalSaleHandler;
        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private List<AuctionProduct> auctionProducts;
        private AuctionProduct selectedProduct;
        private Timer timer;
        public ClientView(InitAuction initAuction, BidHandler bidHandler, Timer timer, FinalSaleHandler finalSaleHandler)
        {
           
            this.initAuction = initAuction;
            this.bidHandler = bidHandler;
            this.finalSaleHandler = finalSaleHandler;
            this.timer = timer;
            auctionProducts = initAuction();
            InitializeComponent();
            foreach (var item in auctionProducts)
            {
                product_ListBox.Items.Add(item.Name);
                
            }
            myTimer.Tick += new EventHandler(TimerEvent);
            myTimer.Interval = 1000;
            myTimer.Start();
            top_Bid.Text = "Minimum bid $";
            bid_Status.Text = "";

            Product.Text = "Product: Select a product to bid on";
        }
        private void TimerEvent(Object myObject, EventArgs myEventArgs)
        {
            timer();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = auctionProducts[product_ListBox.SelectedIndex];
            product_ListBox.Items.Clear();
            foreach (var item in auctionProducts)
            {
                product_ListBox.Items.Add(item.Name);

            }
            UpdateProductSelection();
        }

        public void UpdateProducts(List<AuctionProduct> products)
        {
            this.auctionProducts = products;
        }


        private void UpdateProductSelection()
        {
            if (selectedProduct == null)
            {
                return;
            }

            Product.Text = "Product: " + selectedProduct.Name;
            DateTime temp = Convert.ToDateTime(selectedProduct.AuctionEndTime);
             TimeSpan difference = temp.Subtract(DateTime.Now);
      //      TimeSpan difference = endAuctionTimes[0].Subtract(DateTime.Now);
            if (difference.CompareTo(TimeSpan.Zero)< 0)
            {
                Timer.Text = selectedProduct.Owner == null ? "Timer: " + 0 : selectedProduct.Owner;
                Status_Color.BackColor = Color.Red;
                bid_Button.Enabled = false;
            }
            else
            {
                Timer.Text = "Timer: " + difference;
                Status_Color.BackColor = Color.LightSkyBlue;
                bid_Button.Enabled = true;
            }
            
            
            bid_Count.Text = "(" + selectedProduct.NumberOfBids + "bids)";
            top_Bid.Text = "Minimum bid $" + selectedProduct.MinimumBid;
            bid_Status.Text = "";
        }

        private void bid_Button_Click(object sender, EventArgs e)
        {
            try {
                int bidAttempt = Int32.Parse(bid_TextBox.Text);
                if (bidAttempt < Int32.Parse(top_Bid.Text.Substring(top_Bid.Text.IndexOf('$') + 1)))
                {
                    throw new Exception();
                }
                Transaction temp = new Transaction(bidAttempt, TransactionType.TraditionalBid);
                bidHandler(selectedProduct, temp);
                bid_Status.Text = "Successful bid.";
            }
            catch(Exception)
            {
                bid_Status.Text = "Invalid bid. Try again.";
            }
        }
    }
}
