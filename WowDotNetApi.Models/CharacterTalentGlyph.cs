using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterTalentGlyph
    {
        [DataMember(Name="glyph")]
        public int Glyph { get; set; }

        [DataMember(Name = "item")]
        public int Item { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }
    }
}
