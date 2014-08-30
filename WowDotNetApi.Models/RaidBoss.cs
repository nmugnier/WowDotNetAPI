using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
	public class RaidBoss
	{
        [DataMember(Name="name")]
		public string Name { get; set; }

        [DataMember(Name = "normalKills")]
        public int NormalKills { get; set; }

        [DataMember(Name = "heroicKills")]
        public int HeroicKills { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
	}
}
