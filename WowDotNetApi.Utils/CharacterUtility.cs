﻿using System.Collections.Generic;

namespace WowDotNetAPI.Utilities
{
    public static class CharacterUtility
    {
        public static string BuildOptionalQuery(CharacterOptions characterOptions)
        {
            var query = "&fields=";
            var tmp = new List<string>();

            if ((characterOptions & CharacterOptions.GetGuild) == CharacterOptions.GetGuild)
                tmp.Add("guild");

            if ((characterOptions & CharacterOptions.GetStats) == CharacterOptions.GetStats)
                tmp.Add("stats");

            if ((characterOptions & CharacterOptions.GetTalents) == CharacterOptions.GetTalents)
                tmp.Add("talents");

            if ((characterOptions & CharacterOptions.GetItems) == CharacterOptions.GetItems)
                tmp.Add("items");

            if ((characterOptions & CharacterOptions.GetReputation) == CharacterOptions.GetReputation)
                tmp.Add("reputation");

            if ((characterOptions & CharacterOptions.GetTitles) == CharacterOptions.GetTitles)
                tmp.Add("titles");

            if ((characterOptions & CharacterOptions.GetProfessions) == CharacterOptions.GetProfessions)
                tmp.Add("professions");

            if ((characterOptions & CharacterOptions.GetAppearance) == CharacterOptions.GetAppearance)
                tmp.Add("appearance");

            if ((characterOptions & CharacterOptions.GetPetSlots) == CharacterOptions.GetPetSlots)
                tmp.Add("petSlots");

            if ((characterOptions & CharacterOptions.GetMounts) == CharacterOptions.GetMounts)
                tmp.Add("mounts");

            if ((characterOptions & CharacterOptions.GetPets) == CharacterOptions.GetPets)
                tmp.Add("pets");

            if ((characterOptions & CharacterOptions.GetAchievements) == CharacterOptions.GetAchievements)
                tmp.Add("achievements");

            if ((characterOptions & CharacterOptions.GetProgression) == CharacterOptions.GetProgression)
                tmp.Add("progression");

            if ((characterOptions & CharacterOptions.GetFeed) == CharacterOptions.GetFeed)
                tmp.Add("feed");

            if ((characterOptions & CharacterOptions.GetPvP) == CharacterOptions.GetPvP)
                tmp.Add("pvp");

            if ((characterOptions & CharacterOptions.GetQuests) == CharacterOptions.GetQuests)
                tmp.Add("quests");

            if ((characterOptions & CharacterOptions.GetHunterPets) == CharacterOptions.GetHunterPets)
                tmp.Add("hunterPets");
            

            if (tmp.Count == 0) 
                return string.Empty;

            query += string.Join(",", tmp.ToArray());
            return query;
        }
    }
}
