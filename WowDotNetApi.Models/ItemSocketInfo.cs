using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemSocketInfo
    {
        [DataMember(Name="sockets")]
        public IEnumerable<ItemSocket> Sockets { get; set; }  
    }
}
