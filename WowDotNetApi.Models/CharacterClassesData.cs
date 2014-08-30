using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterClassesData
    {
        [DataMember(Name = "classes")]
        public IEnumerable<CharacterClassInfo> Classes { get; set; }
    }
}
