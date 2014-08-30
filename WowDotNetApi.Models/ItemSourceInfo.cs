using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemSourceInfo
    {
        [DataMember(Name = "sourceId")]
        public int SourceId { get; set; }

        [DataMember(Name = "sourceType")]
        public string SourceType { get; set; }
    }
}
