﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Test;
using System.Collections;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;
using WowDotNetAPI;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class DataTests
    {
        private static WowExplorer explorer;
        private static string APIKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_BattleGroups_Test()
        {
            var battleGroups = explorer.GetBattlegroupsData();

            Assert.IsTrue(battleGroups.Count() == 14); 
            Assert.IsTrue(battleGroups.Any(r => r.Name == "Nightfall"));
        }

        [TestMethod]
        public void Get_Character_Races_Data()
        {
            var races = explorer.GetCharacterRaces();

            Assert.IsTrue(races.Count() == 15);
            Assert.IsTrue(races.Any(r => r.Name == "Human" || r.Name == "Night Elf"));
        }

        [TestMethod]
        public void Get_Character_Achievements_Data()
        {
            var characterAchievements = explorer.GetAchievements();

            Assert.AreEqual(11, characterAchievements.Count());
            var achievementList = characterAchievements.First<AchievementList>(a => a.Id == 92);
            var gotMyMindOnMyMoneyAchievement = achievementList.Achievements.First<AchievementInfo>(a => a.Id == 1181);
            Assert.AreEqual("Loot 25,000 gold", gotMyMindOnMyMoneyAchievement.Criteria.ElementAt(0).Description);

        }

        [TestMethod]
        public void Get_Character_Classes_Data()
        {
            var classes = explorer.GetCharacterClasses();

            Assert.IsTrue(classes.Count() == 11);
            Assert.IsTrue(classes.Any(r => r.Name == "Warrior" || r.Name == "Death Knight"));
        }

        [TestMethod]
        public void Get_Guild_Achievements_Data()
        {
            var guildAchievementsList = explorer.GetGuildAchievements();
            Assert.AreEqual(7, guildAchievementsList.Count());
        }

        [TestMethod]
        public void Get_Guild_Rewards_Data()
        {
            var rewards = explorer.GetGuildRewards();
            Assert.IsTrue(rewards.Count() == 60);
            Assert.IsTrue(rewards.Any(r => r.Achievement != null));
        }


        [TestMethod]
        public void Get_Guild_Perks_Data()
        {
            var perks = explorer.GetGuildPerks();
            Assert.IsTrue(perks.Count() == 24);
            Assert.IsTrue(perks.Any(r => r.Spell != null));
        }

        [TestMethod]
        public void Get_Realms_From_Json_String()
        {
            var realms1 = explorer.GetRealms();
            var realms2 = JsonUtility.FromJSONString<RealmsData>(TestStrings.TestRealms).Realms;
            var realms3 = realms1.Intersect(realms2);
            Assert.AreEqual(0, realms3.Count());

        }

        [TestMethod]
        public void Get_Character_From_Json_String()
        {
            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetEverything);
            var briandekFromJsonString = JsonUtility.FromJSONString<Character>(TestStrings.TestCharacter);
            Assert.AreEqual(0, briandek.CompareTo(briandekFromJsonString));

        }

    }

}
