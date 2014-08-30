using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemSocket
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
