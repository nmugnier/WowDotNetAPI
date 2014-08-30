using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterRacesData
    {
        [DataMember(Name="races")]
        public IEnumerable<CharacterRaceInfo> Races { get; set; }
    }
}
