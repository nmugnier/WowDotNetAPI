using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterPetSlot
    {
        [DataMember(Name = "abilities")]
        public IEnumerable<int> Abilities { get; set; }

        [DataMember(Name = "battlePetId")]
        public int BattlePetId { get; set; }

        [DataMember(Name = "isEmpty")]
        public bool IsEmpty { get; set; }

        [DataMember(Name = "isLocked")]
        public bool IsLocked { get; set; }

        [DataMember(Name = "slot")]
        public int Slot { get; set; }
    }
}
