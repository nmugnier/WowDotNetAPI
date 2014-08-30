﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    [DataContract]
    public class GuildRewardInfo
    {
        [DataMember(Name = "minGuildLevel")]
        public int MinGuildLevel { get; set; }

        [DataMember(Name = "minGuildRepLevel")]
        public int MinGuildRepLevel { get; set; }

        [DataMember(Name = "races")]
        public IEnumerable<int> Races { get; set; }

        [DataMember(Name = "achievement")]
        public GuildRewardAchievementInfo Achievement { get; set; }

        [DataMember(Name = "item")]
        public GuildRewardItemInfo Item { get; set; }

    }
}
