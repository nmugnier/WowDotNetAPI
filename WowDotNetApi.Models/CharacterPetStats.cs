using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterPetStats
    {
        [DataMember(Name = "breedId")]
        public int BreedId { get; set; }

        [DataMember(Name = "health")]
        public int Health { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "petQualityId")]
        public int QualityId { get; set; }

        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "speciesId")]
        public int SpeciesId { get; set; }

        [DataMember(Name = "speed")]
        public int Speed { get; set; }
    }
}
