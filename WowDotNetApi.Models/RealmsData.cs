using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class RealmsData
    {
        [DataMember(Name = "realms")]
        public IEnumerable<Realm> Realms { get; set; }
    }
}
