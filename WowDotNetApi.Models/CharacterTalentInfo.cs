using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterTalentInfo
    {
        [DataMember(Name = "tier")]
        public int Tier { get; set; }

        [DataMember(Name = "column")]
        public int Column { get; set; }

        [DataMember(Name = "spell")]
        public CharacterTalentSpell Spell { get; set; }
    }
}
