using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemWeaponInfo
    {
        [DataMember(Name = "damage")]
        public ItemWeaponDamage Damage { get; set; }

        [DataMember(Name="weaponSpeed")]
        public double WeaponSpeed { get; set; }

        [DataMember(Name = "dps")]
        public double Dps { get; set; }
    }
}
