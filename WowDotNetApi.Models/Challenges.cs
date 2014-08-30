using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class Challenges
    {
        [DataMember(Name = "challenge")]
        public IEnumerable<Challenge> Challenge { get; set; }
    }
}
