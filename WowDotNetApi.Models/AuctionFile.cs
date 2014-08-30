using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class AuctionFile
    {
        [DataMember(Name = "url")]
        public string URL { get; set; }
        [DataMember(Name = "lastModified")]
        public long LastModified { get; set; }
    }
}
