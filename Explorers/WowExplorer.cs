using System.Collections.Generic;
using System.Linq;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI
{
    public class WowExplorer : IExplorer
    {
        public Region Region { get; set; }
        public Locale Locale { get; set; }
        public string ApiKey { get; set; }

        public string Host { get; set; }

        public WowExplorer(Region region, Locale locale, string apiKey)
        {
            Region = region;
            Locale = locale;
            ApiKey = apiKey;

            switch (Region)
            {
                case Region.EU:
                    Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    Host = "https://www.battlenet.com.cn";
                    break;
                default:
                    Host = "https://us.api.battle.net";
                    break;
            }
        }

        #region Character

        public Character GetCharacter(string realm, string name)
        {
            return GetCharacter(Region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(Region region, string realm, string name)
        {
            return GetCharacter(region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(string realm, string name, CharacterOptions characterOptions)
        {
            return GetCharacter(Region, realm, name, characterOptions);
        }

        public Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions)
        {
            Character character;

            TryGetData(
                string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, Locale,
                    CharacterUtility.BuildOptionalQuery(characterOptions), ApiKey),
                out character);

            return character;
        }

        #endregion

        #region Guild

        public Guild GetGuild(string realm, string name)
        {
            return GetGuild(Region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(Region region, string realm, string name)
        {
            return GetGuild(region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(string realm, string name, GuildOptions realmOptions)
        {
            return GetGuild(Region, realm, name, realmOptions);
        }

        public Guild GetGuild(Region region, string realm, string name, GuildOptions realmOptions)
        {
            Guild guild;

            TryGetData(
                string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, Locale,
                    GuildUtility.BuildOptionalQuery(realmOptions), ApiKey),
                out guild);

            return guild;
        }

        #endregion

        #region Realms
        public IEnumerable<Realm> GetRealms()
        {
            RealmsData realmsData;

            TryGetData(
                string.Format(@"{0}/wow/realm/status?locale={1}&apikey={2}", Host, Locale, ApiKey),
                out realmsData);

            return (realmsData != null) ? realmsData.Realms : null;
        }

        #endregion

        #region Auctions

        public Auctions GetAuctions(string realm)
        {
            AuctionFiles auctionFiles;

            TryGetData(
                string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}", Host, realm.ToLower().Replace(' ', '-'), Locale, ApiKey),
                out auctionFiles);

            if (auctionFiles == null || !auctionFiles.Files.Any())
                return null;

            Auctions auctions;
            TryGetData(auctionFiles.Files.Last().URL, out auctions);

            return auctions;
        }

        #endregion

        #region Items
        public Item GetItem(int id)
        {
            Item item;

            TryGetData(
                string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}", Host, id, Locale, ApiKey),
                out item);

            return item;
        }

        public IEnumerable<ItemClassInfo> GetItemClasses()
        {
            ItemClassData itemclassdata;

            TryGetData(
                string.Format(@"{0}/wow/data/item/classes?locale={1}&apikey={2}", Host, Locale, ApiKey),
                out itemclassdata);

            return (itemclassdata != null) ? itemclassdata.Classes : null;
        }

        #endregion

        #region CharacterRaceInfo
        public IEnumerable<CharacterRaceInfo> GetCharacterRaces()
        {
            CharacterRacesData charRacesData;

            TryGetData(
                string.Format(@"{0}/wow/data/character/races?locale={1}&apikey={2}", Host, Locale, ApiKey),
                out charRacesData);

            return (charRacesData != null) ? charRacesData.Races : null;
        }
        #endregion

        #region CharacterClassInfo
        public IEnumerable<CharacterClassInfo> GetCharacterClasses()
        {
            CharacterClassesData characterClasses;

            TryGetData(
                string.Format(@"{0}/wow/data/character/classes?locale={1}&apikey={2}", Host, Locale, ApiKey),
                out characterClasses);

            return (characterClasses != null) ? characterClasses.Classes : null;
        }
        #endregion

        #region GuildRewardInfo
        public IEnumerable<GuildRewardInfo> GetGuildRewards()
        {
            GuildRewardsData guildRewardsData;
            
            TryGetData(
                string.Format(@"{0}/wow/data/guild/rewards?locale={1}&apikey={2}", Host, Locale, ApiKey),
                out guildRewardsData);
            
            return (guildRewardsData != null) ? guildRewardsData.Rewards : null;
        }
        #endregion

        #region GuildPerkInfo
        public IEnumerable<GuildPerkInfo> GetGuildPerks()
        {
            GuildPerksData guildPerksData;

            TryGetData(
                 string.Format(@"{0}/wow/data/guild/perks?locale={1}&apikey={2}", Host, Locale, ApiKey), 
                 out guildPerksData);

            return (guildPerksData != null) ? guildPerksData.Perks : null;
        }
        #endregion

        #region Achievements
        public AchievementInfo GetAchievement(int id)
        {
            AchievementInfo achievement;

            TryGetData(
                string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}", Host, id, Locale, ApiKey),
                out achievement);

            return achievement;
        }

        public IEnumerable<AchievementList> GetAchievements()
        {
            AchievementData achievementData;
            
            TryGetData(
                string.Format(@"{0}/wow/data/character/achievements?locale={1}&apikey={2}", Host, Locale, ApiKey),
                out achievementData);

            return (achievementData != null) ? achievementData.Lists : null;
        }

        public IEnumerable<AchievementList> GetGuildAchievements()
        {
            AchievementData achievementData;

            TryGetData(
                string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}", Host, Locale, ApiKey),
                out achievementData);

            return (achievementData != null) ? achievementData.Lists : null;
        }

        #endregion

        #region Battlegroups
        public IEnumerable<BattlegroupInfo> GetBattlegroupsData()
        {
            BattlegroupData battlegroupData;            
            
            TryGetData(
                string.Format(@"{0}/wow/data/battlegroups/?locale={1}&apikey={2}", Host, Locale, ApiKey), 
                out battlegroupData);

            return (battlegroupData != null) ? battlegroupData.Battlegroups : null;
        }
        #endregion

        #region Challenges
        public Challenges GetChallenges(string realm)
        {
            Challenges challenges;

            TryGetData(
                string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}", Host, realm, Locale, ApiKey), 
                out challenges);

            return challenges;
        }
        #endregion

        private static void TryGetData<T>(string url, out T requestedObject) where T : class
        {
            try
            {
                requestedObject = JsonUtility.FromJSON<T>(url);
            }
            catch
            {                
                requestedObject = null;
                throw;
            }
        }
    }
}
