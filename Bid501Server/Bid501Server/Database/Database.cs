using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501Server.Database
{
    public class Database
    {
        private Transaction transaction { get; set; }
        private Client client { get; set; }
        public BindingList<AuctionProduct> ProductList { get; private set; }

        public Database()
        {
            
        }

        public void AddProduct(AuctionProduct product)
        {
            ProductList.Add(product);
        }
    }
}
