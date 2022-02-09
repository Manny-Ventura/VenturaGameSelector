using System;

namespace GameSelectorStarter
{
    public enum GameGenre
    {
        NONE,
        Luck,
        Strategy,
        Diplomacy,
        Knowledge,
        Dexterity
    }

    public enum GameMedia
    {
        Card, 
        Board,
        Computer
    }
    public enum GameDifficulty
    {
        Low,
        Medium,
        High
    }

    public static class GameGenreExtension
    {
        static public GameGenre ConvertFromString(this GameGenre genre, string name)
        {
            foreach (GameGenre g in Enum.GetValues(typeof(GameGenre)))
            {
                if (name.Equals(g.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    return g;
            }
            return genre;
        }
    }
    public static class GameMediaExtension
    {
        static public GameMedia ConvertFromString(this GameMedia media, string name)
        {
            foreach (GameMedia g in Enum.GetValues( typeof(GameMedia)))
            {
                if (name.Equals(g.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    return g;
            }
            return media;
        }
    }
}