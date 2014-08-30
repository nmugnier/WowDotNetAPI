using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterRatedBattleground
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "played")]
        public int Played { get; set; }

        [DataMember(Name = "won")]
        public int Won { get; set; }
    }
}
