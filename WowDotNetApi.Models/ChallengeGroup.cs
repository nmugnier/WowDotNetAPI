using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ChallengeGroup
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }
               
        [DataMember(Name = "faction")]
        public string Faction { get; set; }

        [DataMember(Name = "isRecurring")]
        public bool IsRecurring { get; set; }

        [DataMember(Name = "medal")]
        public string Medal { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<ChallengeMember> Members { get; set; }

        [DataMember(Name = "ranking")]
        public int Ranking { get; set; }

        [DataMember(Name = "time")]
        public ChallengeTime Time { get; set; }
    }
}
