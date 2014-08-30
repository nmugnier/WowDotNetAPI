using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class ItemClassData
    {
        [DataMember(Name = "classes")]
        public IEnumerable<ItemClassInfo> Classes { get; set; }
    }

}
