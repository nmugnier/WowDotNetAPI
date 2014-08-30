using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemWeaponDamage
    {
        [DataMember(Name="min")]
        public int MinDamage { get; set; }

        [DataMember(Name = "max")]
        public int MaxDamage { get; set; }
        
    }
}
