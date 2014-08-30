using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemGemInfo
    {
        [DataMember(Name = "bonus")]
        public ItemGemBonusInfo Bonus { get; set; }

        [DataMember(Name = "type")]
        public ItemGemType Type { get; set; }
    }
}
