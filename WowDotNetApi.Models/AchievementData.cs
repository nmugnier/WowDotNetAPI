using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class AchievementData
    {
        [DataMember(Name = "achievements")]
        public IEnumerable<AchievementList> Lists { get; set; }
    }
}
