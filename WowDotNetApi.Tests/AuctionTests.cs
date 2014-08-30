using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetApi.Common;
using WowDotNetApi.Core;

namespace WowDotNetApi.Tests
{
    [TestClass]
    public class AuctionTests
    {
        private static WowApiClient _client;
        private const string ApiKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _client = new WowApiClient(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public async Task Get_US_Realm_Auction_Data()
        {
            var auctions = await _client.GetAuctionsAsync("Skullcrusher");
            Assert.IsTrue(auctions.Horde.Auctions.Any());
        }

        [TestMethod]
        public async Task Get_EU_Realm_Auction_Data()
        {
            _client.Host = WowApiClient.GetRegion(Region.EU);
            _client.Locale = Locale.fr_FR;

            var auctions = await _client.GetAuctionsAsync("Twisting Nether");
            Assert.IsTrue(auctions.Horde.Auctions.Any());
        }

        [TestMethod]
        public async Task Get_TW_Realm_Auction_Data()
        {
            _client.Host = WowApiClient.GetRegion(Region.TW);
            _client.Locale = Locale.zh_TW;

            var auctions = await _client.GetAuctionsAsync("Balnazzar");
            Assert.IsTrue(auctions.Horde.Auctions.Any());
        }
    }
}