﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetApi.Models
{
    //public enum ItemQuality

    [DataContract]
	public class CharacterItem
	{
        [DataMember(Name="id")]
		public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "quality")]
        public int Quality { get; set; }

        [DataMember(Name = "tooltipParams")]
        public ItemTooltipParameters TooltipParams { get; set; }

		[DataMember(Name = "stats")]
		public IEnumerable<ItemStat> Stats { get; set; }
	}
}
