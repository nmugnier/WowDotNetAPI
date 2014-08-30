using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterPvP
    {
        [DataMember(Name = "ratedBattlegrounds")]
        public CharacterRatedBattlegrounds RatedBattlegrounds { get; set; }

        [DataMember(Name = "arenaTeams")]
        public IEnumerable<CharacterArenaTeam> ArenaTeams { get; set; }

        [DataMember(Name = "totalHonorableKills")]
        public int TotalHonorableKills { get; set; }
    }
}
