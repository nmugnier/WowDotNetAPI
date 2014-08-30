using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models;

namespace WowDotNetAPI
{
    public interface IExplorerAsync
    {
        Task<Character> GetCharacterAsync(string realm, string name);
        Task<Character> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions);

        Task<Character> GetCharacterAsync(Region region, string realm, string name);
        Task<Character> GetCharacterAsync(Region region, string realm, string name, CharacterOptions characterOptions);

        Task<Guild >GetGuildAsync(string realm, string name);
        Task<Guild> GetGuildAsync(string realm, string name, GuildOptions guildOptions);

        Task<Guild> GetGuildAsync(Region region, string realm, string name);
        Task<Guild> GetGuildAsync(Region region, string realm, string name, GuildOptions guildOptions);

        Task<AchievementInfo> GetAchievementAsync(int id);

        Task<IEnumerable<AchievementList>> GetAchievementsAsync();
        Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync();

        Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync();

        Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync();

        Task<IEnumerable<Realm>> GetRealmsStatusAsync();

        Task<Auctions> GetAuctionsAsync(string realm);

        Task<Item> GetItemAsync(int id);

        Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync();

        Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync();

        Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync();

        Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync();

        Task<Challenges> GetChallengesAsync(string realm);

    }
}
