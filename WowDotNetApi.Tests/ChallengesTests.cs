using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetApi.Common;
using WowDotNetApi.Core;
using WowDotNetApi.Models;

namespace WowDotNetApi.Tests
{
    [TestClass]
    public class ChallengesTests
    {
        private static WowApiClient _client;
        private static Challenges _challenges;
        private const string ApiKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _client = new WowApiClient(Region.US, Locale.en_US, ApiKey);            
        }

        [TestMethod]
        public async Task Get_Challenges_From_Skullcrusher()
        {
            _challenges = await _client.GetChallengeRealmAsync("skullcrusher");
            Assert.IsTrue(_challenges.Challenge.Any());            
            Assert.IsTrue(_challenges.Challenge.First().Groups.Any());
            Assert.IsTrue(_challenges.Challenge.First().Map.Name != "");
        }
    }
}
