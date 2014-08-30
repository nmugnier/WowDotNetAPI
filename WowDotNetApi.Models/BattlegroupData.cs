using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class BattlegroupData
    {
        [DataMember(Name = "battlegroups")]
        public IEnumerable<BattlegroupInfo> Battlegroups { get; set; }
    }
}
