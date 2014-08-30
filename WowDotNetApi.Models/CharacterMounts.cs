using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterMounts
    {
        [DataMember(Name = "numCollected")]
        public int NumCollected { get; set; }

        [DataMember(Name = "numNotCollected")]
        public int NumNotCollected { get; set; }
        
        [DataMember(Name = "collected")]
        public IEnumerable<CharacterMount> Collected { get; set; }        
    }
}
