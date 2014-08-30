using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemSpellInfo
    {
        [DataMember(Name="spellId")]
        public int SpellId { get; set; }
        
        [DataMember(Name="nCharges")]
        public int NCharges { get; set; }
        
        [DataMember(Name="consumable")]
        public bool Consumable { get; set; }

        [DataMember(Name = "categoryId")]
        public int CategoryId { get; set; }

        [DataMember(Name = "spell")]
        public ItemSpell Spell { get; set; }
    }
}
