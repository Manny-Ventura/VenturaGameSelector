using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class Game
    {
        public string Name { get; private set; }
        public int AverageTime { get; private set; }
        public int MaxPlayers { get; private set; }
        public int Difficulty { get; private set; }
        public string Media { get; private set; }
        public List<GameGenre> GenreList { get; private set; }

        public Game(string name, int avgTime, int maxPlayers, int difficulty, string media)
        {
            GenreList = new List<GameGenre>();
            Name = name;
            AverageTime = avgTime;
            MaxPlayers = MaxPlayers;
            Difficulty = difficulty;
            Media = media;
        }
        public void AddType(GameGenre genre)
        {
            GenreList.Add(genre);
        }
    }
}
