using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class AuctionHouseSide
    {
        [DataMember(Name = "auctions")]
        public IEnumerable<Auction> Auctions { get; set; }
    }
}
