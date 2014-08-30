using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
	public class Progression
	{
        [DataMember(Name="raids")]
		public IEnumerable<Raid> Raids { get; set; }
	}
}
