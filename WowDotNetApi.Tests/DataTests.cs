using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetApi.Common;
using WowDotNetApi.Core;
using WowDotNetApi.Models;

namespace WowDotNetApi.Tests
{
    [TestClass]
    public class DataTests
    {
        private static WowApiClient _client;
        private const string ApiKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _client = new WowApiClient(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public async Task Get_BattleGroups_Test()
        {
            var battleGroups = await _client.GetBattlegroupsDataAsync();

            Assert.IsTrue(battleGroups.Count() == 14); 
            Assert.IsTrue(battleGroups.Any(r => r.Name == "Nightfall"));
        }

        [TestMethod]
        public async Task Get_Character_Races_Data()
        {
            var races = await _client.GetCharacterRacesAsync();

            Assert.IsTrue(races.Count() == 15);
            Assert.IsTrue(races.Any(r => r.Name == "Human" || r.Name == "Night Elf"));
        }

        [TestMethod]
        public async Task Get_Character_Achievements_Data()
        {
            var characterAchievements = await _client.GetAchievementsAsync();

            Assert.AreEqual(11, characterAchievements.Count());
            var achievementList = characterAchievements.First(a => a.Id == 92);
            var gotMyMindOnMyMoneyAchievement = achievementList.Achievements.First(a => a.Id == 1181);
            Assert.AreEqual("Loot 25,000 gold", gotMyMindOnMyMoneyAchievement.Criteria.ElementAt(0).Description);

        }

        [TestMethod]
        public async Task Get_Character_Classes_Data()
        {
            var classes = await _client.GetCharacterClassesAsync();

            Assert.IsTrue(classes.Count() == 11);
            Assert.IsTrue(classes.Any(r => r.Name == "Warrior" || r.Name == "Death Knight"));
        }

        [TestMethod]
        public async Task Get_Guild_Achievements_Data()
        {
            var guildAchievementsList = await _client.GetGuildAchievementsAsync();
            Assert.AreEqual(7, guildAchievementsList.Count());
        }

        [TestMethod]
        public async Task Get_Guild_Rewards_Data()
        {
            var rewards = await _client.GetGuildRewardsAsync();
            Assert.IsTrue(rewards.Count() == 60);
            Assert.IsTrue(rewards.Any(r => r.Achievement != null));
        }


        [TestMethod]
        public async Task Get_Guild_Perks_Data()
        {
            var perks = await _client.GetGuildPerksAsync();
            Assert.IsTrue(perks.Count() == 24);
            Assert.IsTrue(perks.Any(r => r.Spell != null));
        }
    }
}
