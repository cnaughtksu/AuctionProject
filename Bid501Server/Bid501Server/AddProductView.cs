using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501Server
{
    public delegate void NewProduct(Database.AuctionProduct prod);
    public partial class AddProductView : Form
    {
        private List<Database.AuctionProduct> newProducts;
        private NewProduct newProduct;
        public AddProductView(NewProduct newProduct)
        {
            InitializeComponent();
            newProducts = new List<Database.AuctionProduct>();
            newProducts.Add(new Database.AuctionProduct("Nintendo Switch", 200, 0, DateTime.Now.AddMinutes(2).ToString("HH:MM tt"),null));
            newProducts.Add(new Database.AuctionProduct("Renaissance Artwork", 1000, 0, DateTime.Now.AddMinutes(2).ToString("HH:MM tt"), null));
            newProducts.Add(new Database.AuctionProduct("Antique Knife", 50, 0, DateTime.Now.AddMinutes(2).ToString("HH:MM tt"), null));
            newProducts.Add(new Database.AuctionProduct("Racing Horse", 5000, 0, DateTime.Now.AddMinutes(2).ToString("HH:MM tt"), null));
            foreach (var item in newProducts)
            {
                NewProd_ListBox.Items.Add(item.Name);
            }
            this.newProduct = newProduct;
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            Database.AuctionProduct popped = newProducts[0];
            newProduct(popped);
            NewProd_ListBox.Items.RemoveAt(0);
            newProducts.RemoveAt(0);
        }
    }
}