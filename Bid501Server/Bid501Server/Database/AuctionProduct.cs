using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Bid501Server.Database
{
    public class AuctionProduct
    {
        public string Name { get; private set; }
        public decimal MinimumBid { get; set; }
        public int NumberOfBids { get; set; }

        public string AuctionEndTime { get; set; }
        public string Owner { get; set; }

        public AuctionProduct(string Name, decimal MinimumBid, int NumberOfBids, string AuctionEndTime, string owner)
        {
            this.Name = Name;
            this.MinimumBid = MinimumBid;
            this.NumberOfBids = NumberOfBids;
            this.AuctionEndTime = AuctionEndTime;
            this.Owner = owner;
        }
    }
}
