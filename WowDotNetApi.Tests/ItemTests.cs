using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetApi.Common;
using WowDotNetApi.Core;

namespace WowDotNetApi.Tests
{
    [TestClass]
    public class ItemTests
    {
        private static WowApiClient _client;
        private const string ApiKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _client = new WowApiClient(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public async Task Get_Sample_Item_38268()
        {
            var sampleItem = await _client.GetItemAsync(38268);

            Assert.AreEqual("Spare Hand", sampleItem.Name);
            Assert.AreEqual("Give to a Friend", sampleItem.Description);
            Assert.AreEqual("inv_gauntlets_09", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(0, sampleItem.ItemBind);
            Assert.AreEqual("WORLD_DROP", sampleItem.ItemSource.SourceType);
            Assert.AreEqual(4, sampleItem.WeaponInfo.Damage.MaxDamage);
        }



        [TestMethod]
        public async Task Get_Sample_Item_39564()
        {
            var sampleItem = await _client.GetItemAsync(39564);

            Assert.AreEqual(@"Heroes' Bonescythe Legplates", sampleItem.Name);
            Assert.AreEqual("", sampleItem.Description);
            Assert.AreEqual("inv_pants_mail_15", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(1, sampleItem.ItemBind);
            Assert.AreEqual("VENDOR", sampleItem.ItemSource.SourceType);

            Assert.AreEqual(null, sampleItem.WeaponInfo);

            Assert.AreEqual(4, sampleItem.AllowableClasses.First());
            Assert.AreEqual(37, sampleItem.BonusStats.ElementAt(2).Amount);

            Assert.AreEqual("BLUE", sampleItem.SocketInfo.Sockets.First().Type);
        }

        [TestMethod]
        public async Task Get_Sample_Item_17182()
        {
            var sampleItem = await _client.GetItemAsync(17182);

            Assert.AreEqual("Sulfuras, Hand of Ragnaros", sampleItem.Name);
            Assert.AreEqual("", sampleItem.Description);
            Assert.AreEqual("inv_hammer_unique_sulfuras", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(1, sampleItem.ItemBind);

            Assert.AreEqual("CREATED_BY_SPELL", sampleItem.ItemSource.SourceType);

            Assert.AreEqual(3.7, sampleItem.WeaponInfo.WeaponSpeed);

            Assert.AreEqual(12, sampleItem.BonusStats.ElementAt(2).Amount);
            Assert.AreEqual("Hurls a fiery ball that causes 343 Fire damage and an additional 85 damage over 10 sec.",
                sampleItem.ItemSpells.First().Spell.Description);
        }


        [TestMethod]
        public async Task Get_Sample_Gem_52210()
        {
            var sampleItem = await _client.GetItemAsync(52210);

            Assert.AreEqual("+40 Parry and +30 Stamina", sampleItem.GemInfo.Bonus.Name);
            Assert.AreEqual("PURPLE", sampleItem.GemInfo.Type.Color);
            Assert.AreEqual(sampleItem.Id, sampleItem.GemInfo.Bonus.SourceItemId);
            Assert.AreEqual(0, sampleItem.GemInfo.Bonus.RequiredSkillRank);
            Assert.AreEqual(0, sampleItem.GemInfo.Bonus.MinLevel);
            Assert.AreEqual(290, sampleItem.GemInfo.Bonus.ItemLevel);
        }
    }
}
