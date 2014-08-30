using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemClassInfo
    {
        [DataMember(Name = "class")]
        public int Class { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
