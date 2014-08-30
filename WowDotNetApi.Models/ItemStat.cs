using System.Runtime.Serialization;

namespace WowDotNetApi.Models {
	[DataContract]
	public class ItemStat {
		[DataMember(Name = "stat")]
		public int Stat { get; set; }

		[DataMember(Name = "amount")]
		public int Amount { get; set; }

		[DataMember(Name = "reforgedAmount")]
		public int ReforgedAmount { get; set; }

		[DataMember(Name = "reforged")]
		public bool Reforged { get; set; }

	}
}
