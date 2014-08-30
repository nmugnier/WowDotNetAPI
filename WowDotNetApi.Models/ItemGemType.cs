using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemGemType
    {
        [DataMember(Name = "type")]
        public string Color { get; set; }
    }
}
