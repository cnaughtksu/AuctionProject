using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace Bid501Server
{
    public delegate List<Database.AuctionProduct> InitProduct();
    public delegate List<Database.Client> InitClients();
    public delegate void OpenAddProduct();
    public partial class ServerView : Form
    {
        private List<Database.AuctionProduct> auctionProducts;
        private List<Database.Client> client;
        private InitProduct initProduct;
        private InitClients initClients;
        private OpenAddProduct openAddProduct;
        public ServerView(InitProduct initProd, InitClients initClients, OpenAddProduct openAddProduct)
        {
            InitializeComponent();
            this.initProduct = initProd;
            this.initClients = initClients;
            this.openAddProduct = openAddProduct;
            auctionProducts = initProduct();
            client = initClients();
            foreach (var item in auctionProducts)
            {
                Product_listBox.Items.Add(item.Name);
            }
            foreach (var item in client)
            {
                Client_ListBox.Items.Add(item.Name);
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            openAddProduct();
        }
        public void UpdateView(List<Database.AuctionProduct> products, List<Database.Client> clients)
        {
            Product_listBox.Items.Clear();
            Client_ListBox.Items.Clear();
            auctionProducts = products;
            foreach(var item in auctionProducts)
            {
                Product_listBox.Items.Add(item.Name);
            }
            foreach (var item in clients)
            {
                Client_ListBox.Items.Add(item.Name);
            }
        }
    }
}
