using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetApi.Common;
using WowDotNetApi.Models;

namespace WowDotNetApi.Core
{
    public interface IWowApiClient
    {
        string Host { get; set; }
        Task<Character> GetCharacterAsync(string realm, string name);
        Task<Character> GetCharacterAsync(Region region, string realm, string name);
        Task<Character> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions);
        Task<Character> GetCharacterAsync(Region region, string realm, string name, CharacterOptions characterOptions);
        Task<Guild> GetGuildAsync(string realm, string name);
        Task<Guild> GetGuildAsync(Region region, string realm, string name);
        Task<Guild> GetGuildAsync(string realm, string name, GuildOptions realmOptions);
        Task<Guild> GetGuildAsync(Region region, string realm, string name, GuildOptions realmOptions);
        Task<IEnumerable<Realm>> GetRealmsStatusAsync();
        Task<Auctions> GetAuctionsAsync(string realm);
        Task<Item> GetItemAsync(int id);
        Task<Item> GetItemSetAsync(int id);
        Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync();
        Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync();
        Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync();
        Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync();
        Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync();
        Task<AchievementInfo> GetAchievementAsync(int id);
        Task<IEnumerable<AchievementList>> GetAchievementsAsync();
        Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync();
        Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync();
        Task<Challenges> GetChallengeRealmAsync(string realm);
        Task<Challenges> GetChallengeRegionAsync();
        Task<object> GetBattlePetAbilityAsync(int id);
        Task<object> GetBattlePetSpeciesAsync(int id);
        Task<object> GetBattlePetStatsAsync(int id);
        Task<object> GetLeaderBoardAsync(string bracket);
        Task<object> GetQuestAsync(int id);
        Task<object> GetRecipeAsync(int id);
        Task<object> GetSpellAsync(int id);
        Task<object> GetTalentsAsync();
        Task<object> GetPetTypesAsync();
    }
}