using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterArenaTeam
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "personalRating")]
        public int PersonalRating { get; set; }

        [DataMember(Name = "teamRating")]
        public int TeamRating { get; set; }

        [DataMember(Name = "size")]
        public string Size { get; set; }
    }
}
