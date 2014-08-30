using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class AuctionFiles
    {
        [DataMember(Name = "files")]
        public IEnumerable<AuctionFile> Files { get; set; }
    }
}
