﻿using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class CharacterTalentSpec
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "role")]
        public string Role { get; set; }

        [DataMember(Name = "backgroundImage")]
        public string BackgroundImage { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "order")]
        public int Order { get; set; }
    }
}
