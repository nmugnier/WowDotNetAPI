using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class GuildMember
    {
        [DataMember(Name="character")]
        public GuildCharacter Character { get; set; }

        [DataMember(Name = "rank")]
        public int Rank { get; set; }
    }
}
