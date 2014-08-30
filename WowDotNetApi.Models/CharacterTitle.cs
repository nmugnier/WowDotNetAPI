using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
	public class CharacterTitle
	{
        [DataMember(Name="id")]
		public int Id { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }
	}
}
