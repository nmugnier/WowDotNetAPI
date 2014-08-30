using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
	public class CharacterTalentGlyphs
	{
        [DataMember(Name = "major")]
        public IEnumerable<CharacterTalentGlyph> Major { get; set; }

        [DataMember(Name = "minor")]
        public IEnumerable<CharacterTalentGlyph> Minor { get; set; }
	}
}
