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
    public class GuildTests
    {
        private static WowApiClient _client;
        private static Guild _guild = null;
        private const string ApiKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _client = new WowApiClient(Region.US, Locale.en_US, ApiKey);
        }

        [TestMethod]
        public async Task Get_Simple_Guild_Immortality_From_Skullcrusher()
        {
            _guild = await _client.GetGuildAsync("skullcrusher", "immortality", GuildOptions.GetEverything);
            Assert.IsTrue(_guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, _guild.Side);
            Assert.IsTrue(_guild.Members.Any());
        }

        [TestMethod]
        public async Task Get_Valid_Human_Member_From_Immortality_Guild()
        {
            _guild = await _client.GetGuildAsync("skullcrusher", "immortality", GuildOptions.GetEverything);
            var guildMember = _guild.Members.FirstOrDefault(m => m.Character.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(guildMember.Character.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(90, guildMember.Character.Level);
            Assert.AreEqual(CharacterClass.WARRIOR, guildMember.Character.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, guildMember.Character.Race);
            Assert.AreEqual(CharacterGender.MALE, guildMember.Character.Gender);

            Assert.AreEqual(7575, guildMember.Character.AchievementPoints);
        }


        [TestMethod]
        public async Task Get_Valid_Night_Elf_Member_From_Immortality_Guild()
        {
            _guild = await _client.GetGuildAsync("skullcrusher", "immortality", GuildOptions.GetEverything);
            var guildMember = _guild.Members.FirstOrDefault(m => m.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(guildMember.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(90, guildMember.Character.Level);
            Assert.AreEqual(CharacterClass.DRUID, guildMember.Character.@Class);
            Assert.AreEqual(CharacterRace.NIGHT_ELF, guildMember.Character.Race);
            Assert.AreEqual(CharacterGender.MALE, guildMember.Character.Gender);
        }

        [TestMethod]
        public async Task Get_Valid_Member_From_Another_Guild()
        {
            var guild = await _client.GetGuildAsync("laughing skull", "deus vox", GuildOptions.GetMembers | GuildOptions.GetAchievements);

            Assert.IsNotNull(guild.Members);
            Assert.IsNotNull(guild.AchievementPoints);

            Assert.IsTrue(guild.Name.Equals("deus vox", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(guild.Realm.Equals("laughing skull", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(guild.Members.Any());

            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public async Task Get_Valid_Member_From_Horde_Guild()
        {
            var guild = await _client.GetGuildAsync("skullcrusher", "rage", GuildOptions.GetMembers);

            Assert.IsNotNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Name.Equals("rage", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(guild.Members.Any());

            Assert.IsTrue(guild.Side == UnitSide.HORDE);
        }

        [TestMethod]
        public async Task Get_Guild_With_Only_Achievements()
        {
            var guild = await _client.GetGuildAsync("skullcrusher", "immortality", GuildOptions.GetAchievements);

            Assert.IsNull(guild.Members);
            Assert.IsNotNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public async Task Get_Guild_With_Only_Members()
        {
            var guild = await _client.GetGuildAsync("skullcrusher", "immortality", GuildOptions.GetMembers);

            Assert.IsNotNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public async Task Get_Guild_With_Only_No_Options()
        {
            var guild = await _client.GetGuildAsync("skullcrusher", "immortality", GuildOptions.None);

            Assert.IsNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public async Task Get_Guild_With_Base_Method_Call()
        {
            var guild = await _client.GetGuildAsync("skullcrusher", "immortality");

            Assert.IsNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }
    }
}
