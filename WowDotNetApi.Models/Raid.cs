using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class Raid
	{
        [DataMember(Name="name")]
		public string Name { get; set; }

        [DataMember(Name = "normal")]
        public int Normal { get; set; }

        [DataMember(Name = "heroic")]
        public int Heroic { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "bosses")]
        public IEnumerable<RaidBoss> Bosses { get; set; }
	}
}
