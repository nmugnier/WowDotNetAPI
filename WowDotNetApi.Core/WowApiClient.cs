using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using WowDotNetApi.Common;
using WowDotNetApi.Helpers;
using WowDotNetApi.Models;

namespace WowDotNetApi.Core
{
    public class WowApiClient : IWowApiClient
    {
        private HttpClient _httpClient;

        private readonly Region _region;
        private readonly string _apiKey;
        private string _host;

        public string Host
        {
            get { return _host; }
            set
            {
                if (_host == value)
                    return;

                _httpClient = new HttpClient { BaseAddress = new Uri(value) };
                _host = value;
            }
        }
        public Locale Locale { get; set; }

        public WowApiClient(Region region, Locale locale, string apiKey)
        {
            _region = region;
            Locale = locale;
            _apiKey = apiKey;

            Host = GetRegion(region);
        }

        public static string GetRegion(Region region)
        {
            switch (region)
            {
                case Region.EU:
                    return "https://eu.api.battle.net";
                case Region.KR:
                    return "https://kr.api.battle.net";
                case Region.TW:
                    return "https://tw.api.battle.net";
                case Region.CN:
                    return "https://www.battlenet.com.cn";
                default:
                    return "https://us.api.battle.net";
            }
        }

        #region Character

        public async Task<Character> GetCharacterAsync(string realm, string name)
        {
            return await GetCharacterAsync(_region, realm, name, CharacterOptions.None);
        }

        public async Task<Character> GetCharacterAsync(Region region, string realm, string name)
        {
            return await GetCharacterAsync(region, realm, name, CharacterOptions.None);
        }

        public async Task<Character> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions)
        {
            return await GetCharacterAsync(_region, realm, name, characterOptions);
        }

        public async Task<Character> GetCharacterAsync(Region region, string realm, string name, CharacterOptions characterOptions)
        {
            return await GetAsync<Character>(string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, Locale,
                    CharacterHelper.BuildOptionalQuery(characterOptions), _apiKey));
        }

        #endregion

        #region Guild

        public Task<Guild> GetGuildAsync(string realm, string name)
        {
            return GetGuildAsync(_region, realm, name, GuildOptions.None);
        }

        public Task<Guild> GetGuildAsync(Region region, string realm, string name)
        {
            return GetGuildAsync(region, realm, name, GuildOptions.None);
        }

        public Task<Guild> GetGuildAsync(string realm, string name, GuildOptions realmOptions)
        {
            return GetGuildAsync(_region, realm, name, realmOptions);
        }

        public async Task<Guild> GetGuildAsync(Region region, string realm, string name, GuildOptions realmOptions)
        {
            return await GetAsync<Guild>(
                string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, Locale,
                    GuildHelper.BuildOptionalQuery(realmOptions), _apiKey));
        }

        #endregion

        #region Realms
        public async Task<IEnumerable<Realm>> GetRealmsStatusAsync()
        {
            var realmsData = await GetAsync<RealmsData>(
                string.Format(@"{0}/wow/realm/status?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (realmsData != null) ? realmsData.Realms : null;
        }

        #endregion

        #region Auctions

        public async Task<Auctions> GetAuctionsAsync(string realm)
        {
            var auctionFiles = await GetAsync<AuctionFiles>(
                string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}", Host, realm.ToLower().Replace(' ', '-'),
                    Locale, _apiKey));

            if (auctionFiles == null)
                return null;

            return await GetAsync<Auctions>(auctionFiles.Files.Last().URL);
        }

        #endregion

        #region Items

        public async Task<Item> GetItemAsync(int id)
        {
            return await GetAsync<Item>(
                string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}", Host, id, Locale, _apiKey));
        }

        public async Task<Item> GetItemSetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync()
        {
            var itemclassdata = await GetAsync<ItemClassData>(
                string.Format(@"{0}/wow/data/item/classes?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (itemclassdata != null) ? itemclassdata.Classes : null;
        }

        #endregion

        #region CharacterRaceInfo

        public async Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync()
        {
            var charRacesData = await GetAsync<CharacterRacesData>(
                string.Format(@"{0}/wow/data/character/races?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (charRacesData != null) ? charRacesData.Races : null;
        }

        #endregion

        #region CharacterClassInfo

        public async Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync()
        {
            var characterClasses = await GetAsync<CharacterClassesData>(
                string.Format(@"{0}/wow/data/character/classes?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (characterClasses != null) ? characterClasses.Classes : null;
        }

        #endregion

        #region GuildRewardInfo

        public async Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync()
        {
            var guildRewardsData = await GetAsync<GuildRewardsData>(
                string.Format(@"{0}/wow/data/guild/rewards?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (guildRewardsData != null) ? guildRewardsData.Rewards : null;
        }

        #endregion

        #region GuildPerkInfo

        public async Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync()
        {
            var guildPerksData = await GetAsync<GuildPerksData>(
                 string.Format(@"{0}/wow/data/guild/perks?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (guildPerksData != null) ? guildPerksData.Perks : null;
        }

        #endregion

        #region Achievements

        public async Task<AchievementInfo> GetAchievementAsync(int id)
        {
            return await GetAsync<AchievementInfo>(
                string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}", Host, id, Locale, _apiKey));
        }

        public async Task<IEnumerable<AchievementList>> GetAchievementsAsync()
        {
            var achievementData = await GetAsync<AchievementData>(
                string.Format(@"{0}/wow/data/character/achievements?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (achievementData != null) ? achievementData.Lists : null;
        }

        public async Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync()
        {
            var achievementData =
                await
                    GetAsync<AchievementData>(
                        string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (achievementData != null) ? achievementData.Lists : null;
        }

        #endregion

        #region Battlegroups

        public async Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync()
        {
            var battlegroupData =
                await
                    GetAsync<BattlegroupData>(
                        string.Format(@"{0}/wow/data/battlegroups/?locale={1}&apikey={2}", Host, Locale, _apiKey));

            return (battlegroupData != null) ? battlegroupData.Battlegroups : null;
        }

        #endregion

        #region Challenges

        public async Task<Challenges> GetChallengeRealmAsync(string realm)
        {
            return
                await
                    GetAsync<Challenges>(string.Format(
                        @"{0}/wow/challenge/{1}?locale={2}&apikey={3}", Host, realm, Locale, _apiKey));
        }

        public async Task<Challenges> GetChallengeRegionAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BattlePets

        public async Task<object> GetBattlePetAbilityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetBattlePetSpeciesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetBattlePetStatsAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PvP

        public async Task<object> GetLeaderBoardAsync(string bracket)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Quest

        public async Task<object> GetQuestAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Recipe

        public async Task<object> GetRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Spell

        public async Task<object> GetSpellAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Talent

        public async Task<object> GetTalentsAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PetTypes

        public async Task<object> GetPetTypesAsync()
        {
            throw new NotImplementedException();
        }

        #endregion



        #region Implementation

        public async Task<T> GetAsync<T>(string url) where T : class
        {
            var response = await _httpClient.GetAsync(url);

            using (var content = await response.Content.ReadAsStreamAsync())
                return new DataContractJsonSerializer(typeof(T)).ReadObject(content) as T;
        }

        #endregion
    }
}
