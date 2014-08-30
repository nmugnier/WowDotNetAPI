using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class AchievementCategory
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "achievements")]
        public IEnumerable<AchievementInfo> Achievements { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
