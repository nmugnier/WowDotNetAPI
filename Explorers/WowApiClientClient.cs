using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WowDotNetAPI
{
    public class WowApiClientClient : IWowApiClient
    {
        private HttpClient _httpClient;

        private readonly Region _region;
        private readonly Locale _locale;
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

        public WowApiClientClient(Region region, Locale locale, string apiKey)
        {
            _region = region;
            _locale = locale;
            _apiKey = apiKey;

            switch (_region)
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
            return await _httpClientWrapper.GetAsync<Character>(string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, _locale,
                    CharacterUtility.BuildOptionalQuery(characterOptions), _apiKey));
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
            return await _httpClientWrapper.GetAsync<Guild>(
                string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, _locale,
                    GuildUtility.BuildOptionalQuery(realmOptions), _apiKey));
        }

        #endregion

        #region Realms
        public async Task<IEnumerable<Realm>> GetRealmsStatusAsync()
        {
            var realmsData = await _httpClientWrapper.GetAsync<RealmsData>(
                string.Format(@"{0}/wow/realm/status?locale={1}&apikey={2}", Host, _locale, _apiKey));

            return (realmsData != null) ? realmsData.Realms : null;
        }

        #endregion

        #region Auctions

        public async Task<Auctions> GetAuctionsAsync(string realm)
        {
            var auctionFiles = await _httpClientWrapper.GetAsync<AuctionFiles>(
                string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}", Host, realm.ToLower().Replace(' ', '-'),
                    _locale, _apiKey));

            if (auctionFiles == null) 
                return null;
            
            return await _httpClientWrapper.GetAsync<Auctions>(auctionFiles.Files.Last().URL);
        }

        #endregion

        #region Items

        public async Task<Item> GetItemAsync(int id)
        {
            return await _httpClientWrapper.GetAsync<Item>(
                string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}", Host, id, _locale, _apiKey));
        }

        public async Task<Item> GetItemSetAsync(int id)
        {
            throw new NotImplementedException();
            return await _httpClientWrapper.GetAsync<Item>(
                string.Format(@"{0}/wow/item/set/{1}?locale={2}&apikey={3}", Host, id, _locale, _apiKey));
        }

        public async Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync()
        {
            var itemclassdata = await _httpClientWrapper.GetAsync<ItemClassData>(
                string.Format(@"{0}/wow/data/item/classes?locale={1}&apikey={2}", Host, _locale, _apiKey));

            return (itemclassdata != null) ? itemclassdata.Classes : null;
        }

        #endregion

        #region CharacterRaceInfo

        public async Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync()
        {
            var charRacesData = await _httpClientWrapper.GetAsync<CharacterRacesData>(
                string.Format(@"{0}/wow/data/character/races?locale={1}&apikey={2}", Host, _locale, _apiKey));

            return (charRacesData != null) ? charRacesData.Races : null;
        }

        #endregion

        #region CharacterClassInfo

        public async Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync()
        {
            var characterClasses = await _httpClientWrapper.GetAsync<CharacterClassesData>(
                string.Format(@"{0}/wow/data/character/classes?locale={1}&apikey={2}", Host, _locale, _apiKey));

            return (characterClasses != null) ? characterClasses.Classes : null;
        }

        #endregion

        #region GuildRewardInfo

        public async Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync()
        {
            var guildRewardsData = await _httpClientWrapper.GetAsync<GuildRewardsData>(
                string.Format(@"{0}/wow/data/guild/rewards?locale={1}&apikey={2}", Host, _locale, _apiKey));
            
            return (guildRewardsData != null) ? guildRewardsData.Rewards : null;
        }

        #endregion

        #region GuildPerkInfo

        public async Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync()
        {
            var guildPerksData = await _httpClientWrapper.GetAsync<GuildPerksData>(
                 string.Format(@"{0}/wow/data/guild/perks?locale={1}&apikey={2}", Host, _locale, _apiKey));

            return (guildPerksData != null) ? guildPerksData.Perks : null;
        }

        #endregion

        #region Achievements

        public async Task<AchievementInfo> GetAchievementAsync(int id)
        {
            return await _httpClientWrapper.GetAsync<AchievementInfo>(
                string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}", Host, id, _locale, _apiKey));
        }

        public async Task<IEnumerable<AchievementList>> GetAchievementsAsync()
        {
            var achievementData = await _httpClientWrapper.GetAsync<AchievementData>(
                string.Format(@"{0}/wow/data/character/achievements?locale={1}&apikey={2}", Host, _locale, _apiKey));

            return (achievementData != null) ? achievementData.Lists : null;
        }

        public async Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync()
        {
            var achievementData =
                await
                    _httpClientWrapper.GetAsync<AchievementData>(
                        string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}", Host, _locale, _apiKey));

            return (achievementData != null) ? achievementData.Lists : null;
        }

        #endregion

        #region Battlegroups

        public async Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync()
        {
            var battlegroupData =
                await
                    _httpClientWrapper.GetAsync<BattlegroupData>(
                        string.Format(@"{0}/wow/data/battlegroups?locale={1}&apikey={2}", Host, _locale, _apiKey));
                   
            return (battlegroupData != null) ? battlegroupData.Battlegroups : null;
        }

        #endregion

        #region Challenges

        public async Task<Challenges> GetChallengeRealmAsync(string realm)
        {
            return
                await
                    _httpClientWrapper.GetAsync<Challenges>(string.Format(
                        @"{0}/wow/challenge/{1}?locale={2}&apikey={3}", Host, realm, _locale, _apiKey));
        }

        public async Task<Challenges> GetChallengeRegionAsync()
        {
            throw new NotImplementedException();

            return
                await
                    _httpClientWrapper.GetAsync<Challenges>(string.Format(
                        @"{0}/wow/challenge/region?locale={1}&apikey={2}", Host, _locale, _apiKey));
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
