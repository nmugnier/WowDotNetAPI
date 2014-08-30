using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetApi.Common;
using WowDotNetApi.Core;
using WowDotNetApi.Models;

namespace WowDotNetApi.Tests
{
    [TestClass]
    public class RealmTests
    {
        private static WowApiClient _client;
        private const string ApiKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _client = new WowApiClient(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public async Task GetAll_US_Realms_Returns_All_Realms()
        {
            var realmList = await _client.GetRealmsStatusAsync();
            Assert.IsTrue(realmList.Any());
        }

        [TestMethod]
        public async Task Get_Valid_US_Realm_Returns_Unique_Realm()
        {
            var realm = (await _client.GetRealmsStatusAsync()).FirstOrDefault(r => r.Name.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsNotNull(realm);
            Assert.IsTrue(realm.Name == "Skullcrusher");
            Assert.IsTrue(realm.Type == RealmType.PVP);
            Assert.IsTrue(realm.Slug == "skullcrusher");
        }

        [TestMethod]
        public async Task Get_All_Realms_By_Type_Returns_Pvp_Realms()
        {
            var realms = (await _client.GetRealmsStatusAsync()).Where(r => r.Type == RealmType.PVP);
            var allCollectedRealmsArePvp = realms.Any() && realms.All(r => r.Type == RealmType.PVP);
            Assert.IsTrue(allCollectedRealmsArePvp);
        }

        [TestMethod]
        public async Task Get_All_Realms_By_Status_Returns_Realms_That_Are_Up()
        {
            var realmList = (await _client.GetRealmsStatusAsync()).Where(r => r.Status == true);
            //All servers being down is likely(maintenance) and will cause test to fail
            var allCollectedRealmsAreUp = realmList.Any() && realmList.All(r => r.Status == true);
            Assert.IsTrue(allCollectedRealmsAreUp);
        }


        [TestMethod]
        public async Task Get_All_Realms_By_Queue_Returns_Realms_That_Do_Not_Have_Queues()
        {
            var realmList = (await _client.GetRealmsStatusAsync()).Where(r => r.Queue == false);
            //All servers getting queues is unlikely but possible and will cause test to fail
            var allCollectedRealmsHaveQueues = realmList.Any() && realmList.All(r => r.Queue == false);
            Assert.IsTrue(allCollectedRealmsHaveQueues);
        }

        [TestMethod]
        public async Task Get_All_Realms_By_Population_Returns_Realms_That_Have_Low_Population()
        {
            var realmList = (await _client.GetRealmsStatusAsync()).Where(r => r.population == "low");
            var allCollectedRealmsHaveLowPopulation = realmList.Any() && realmList.All(r => r.population == "low");
            Assert.IsTrue(allCollectedRealmsHaveLowPopulation);
        }
    }
}
