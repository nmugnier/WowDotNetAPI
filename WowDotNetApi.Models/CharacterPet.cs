﻿using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterPet
    {
        [DataMember(Name = "battlePetId")]
        public int BattlePetId { get; set; }

        [DataMember(Name = "canBattle")]
        public bool CanBattle { get; set; }

        [DataMember(Name = "creatureId")]
        public long CreatureId { get; set; }

        [DataMember(Name = "creatureName")]
        public string CreatureName { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "isFavorite")]
        public bool IsFavorite { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "qualityId")]
        public int QualityId { get; set; }

        [DataMember(Name = "spellId")]
        public long SpellId { get; set; }

        [DataMember(Name = "stats")]
        public CharacterPetStats Stats { get; set; }

    }
}
