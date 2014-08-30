using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class GuildPerkSpellInfo
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "subtext")]
        public string Subtext { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
