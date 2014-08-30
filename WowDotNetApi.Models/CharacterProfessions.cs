using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
	public class CharacterProfessions
	{
        [DataMember(Name="primary")]
		public IEnumerable<CharacterProfession> Primary { get; set; }

        [DataMember(Name = "secondary")]
        public IEnumerable<CharacterProfession> Secondary { get; set; }
	}
}
