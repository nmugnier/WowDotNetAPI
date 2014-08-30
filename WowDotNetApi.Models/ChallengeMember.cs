using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ChallengeMember
    {
        [DataMember(Name = "character")]
        public ChallengeMemberCharacter Character { get; set; }

        [DataMember(Name = "spec")]
        public CharacterTalentSpec Spec { get; set; }
    }
}
