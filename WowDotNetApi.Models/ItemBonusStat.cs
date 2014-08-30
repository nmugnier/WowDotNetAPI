using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemBonusStat
    {
        [DataMember(Name = "stat")]
        public int Stat { get; set; }

        [DataMember(Name = "amount")]
        public int Amount { get; set; }

        [DataMember(Name = "reforged")]
        public bool Reforged { get; set; }
    }
}
