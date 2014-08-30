using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class Challenge
    {
        [DataMember(Name = "groups")]
        public IEnumerable<ChallengeGroup> Groups { get; set; }

        [DataMember(Name = "map")]
        public ChallengeMap Map { get; set; }
    }
}
