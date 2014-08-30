using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    //public enum ReputationStanding

    [DataContract]
    public class CharacterReputation
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "standing")]
        public int Standing { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "max")]
        public int Max { get; set; }
    }
}
