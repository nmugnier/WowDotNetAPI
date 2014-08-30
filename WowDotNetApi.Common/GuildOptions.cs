using System;

namespace WowDotNetApi.Common
{
    [Flags]
    public enum GuildOptions
    {
        None = 0,
        GetMembers = 1,
        GetAchievements = 2,
        GetChallenge = 3,
        GetNews = 4,
        GetEverything = GetMembers | GetAchievements | GetChallenge | GetNews
    }
}