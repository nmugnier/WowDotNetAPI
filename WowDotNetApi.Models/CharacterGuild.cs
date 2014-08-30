using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterGuild
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "realm")]
        public string Realm { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "achievementPoints")]
        public int AchievementPoints { get; set; }

        [DataMember(Name = "members")]
        public int Members { get; set; }

        [DataMember(Name = "emblem")]
        public CharacterGuildEmblem Emblem { get; set; }
    }
}
