using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterRatedBattlegrounds
    {
        [DataMember(Name = "personalRating")]
        public int PersonalRating { get; set; }

        [DataMember(Name = "battlegrounds")]
        public IEnumerable<CharacterRatedBattleground> Battlegrounds { get; set; }
    }
}
