using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class GuildPerkInfo
    {
        [DataMember(Name="guildLevel")]
        public int GuildLevel { get; set; }

        [DataMember(Name = "spell")]
        public GuildPerkSpellInfo Spell { get; set; }

    }
}
