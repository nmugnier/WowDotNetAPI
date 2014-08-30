using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class GuildRewardsData
    {
        [DataMember(Name="rewards")]
        public IEnumerable<GuildRewardInfo> Rewards { get; set; }
    }
}
