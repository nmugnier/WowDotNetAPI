using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class GuildPerksData
    {
        [DataMember(Name="perks")]
        public IEnumerable<GuildPerkInfo> Perks { get; set; }
    }
}
