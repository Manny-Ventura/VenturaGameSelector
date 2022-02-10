using System;
using System.Collections.Generic;
using System.IO;

namespace GameSelectorStarter
{
    class GameSelector
    {
        readonly private GameSet AllGames = new GameSet();
        private Dictionary<string, GameSet> gameCriteria = new Dictionary<string, GameSet>();

        private List<GameSet> currentGenreList = new List<GameSet>();
        private GameMedia media = new GameMedia();

        public GameSelector(string filename)
        {
            LoadGameInfo(filename);
            BuildMa terCriteria();
        }

        private void LoadGameInfo(string filename)
        {
            StreamReader input = new StreamReader(filename);
            while (!input.EndOfStream)
            {
                String line = input.ReadLine();
                string[] fields = line.Split(',');
                try
                {
                    Game game = CreateGameFromRecord(line);
                    AllGames.Add(game);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(line);
                    Console.Error.Write("Exception: ");
                    Console.WriteLine(e.Message);
                }
            }
            input.Close();
        }

        private void BuildMasterCriteria()
        {
            gameCriteria.Clear();
            AddGenre();
            AddMedia();
            // TODO -- need to add more criteria here

            foreach (Game game in AllGames)
            {
                foreach (GameSet set in gameCriteria.Values)
                {
                    set.AddIfFitsCriteria(game);
                }
            }
        }

        private Game CreateGameFromRecord(string line)
        {
            Game game = null;
            string[] fields = line.Split(',');
            if (fields.Length >= 5)
            {
                string name = fields[0];
                int time = int.Parse(fields[1]);
                int maxPlayers = int.Parse(fields[2]);
                int difficulty = int.Parse(fields[3]);
                string type = fields[4];
                game = new Game(name, time, maxPlayers, difficulty, type);
                for (int i = 5; i < fields.Length; i++)
                {
                    // game.AddType(fields[i]);
                    GameGenre g = GameGenre.NONE;
                    g = g.ConvertFromString(fields[i]);

                    game.AddType(g);
                }
            }
            else
            {
                throw new Exception("Too few fields");
            }
            return game;
        }

        private void AddGenre()
        {
            // FIXME -- only the Strategy and Diplomacy entries
            // are correct; the others need their own class
            gameCriteria.Add(GameGenre.Luck.ToString(), new LuckSet());
            gameCriteria.Add(GameGenre.Strategy.ToString(), new StrategySet());
            gameCriteria.Add(GameGenre.Diplomacy.ToString(), new DiplomacySet());
            gameCriteria.Add(GameGenre.Knowledge.ToString(), new KnowledgeSet());
            gameCriteria.Add(GameGenre.Dexterity.ToString(), new DexteritySet());
        }

        private void AddMedia()
        {
            // TODO -- add media
            gameCriteria.Add(GameMedia.Card.ToString(), new CardMedia());
            gameCriteria.Add(GameMedia.Board.ToString(), new BoardMedia());
            gameCriteria.Add(GameMedia.Computer.ToString(), new ComputerMedia());
        }

        // TODO, add methods, if needed, for dificulty, time, num players, etc.

        public GameSet RetrieveCurrentMatches()
        {
            GameSet genreSet = new GameSet();

            GameSet currentMatches = new GameSet();
            currentMatches.UnionWith(AllGames);

            foreach (GameSet set in currentGenreList)
                genreSet.UnionWith(set);
            if (genreSet.Count > 0)
                currentMatches.IntersectWith(genreSet);
           foreach (GameMedia gameMedia in media)
            return (currentMatches);
        }

        public void ClearGenreCriteria()
        {
            currentGenreList = new List<GameSet>();
        }

        /// <summary>
        /// Add one or more genres to the current genre list
        /// </summary>
        /// <param name="genreSet">The HashSet of GameGenre objects.</param>
        public void AddGenreCriteria(HashSet<GameGenre> genreSet)
        {
            List<GameSet> newList = new List<GameSet>(currentGenreList);
            newList.AddRange(GetGenreSetFromSelection(genreSet));
            currentGenreList = newList;
        }
        ///<summary>
        /// Add a media to the game selector media variable
        /// </summary>
        public void AddMediaCriteria(GameMedia gameMedia)
        {
            media = gameMedia;
        }

        /// <summary>
        /// Remove one or more genres from the current list.  The genres
        /// are not guaranteed to be in the list.  If they are not,
        /// they are silently ignored.
        /// </summary>
        /// <param name="genreSet">The HashSet of GameGenre objects.</param>
        public void RemoveGenreCriteria(HashSet<GameGenre> genreSet)
        {
            List<GameSet> newList = new List<GameSet>(currentGenreList);
            List<GameSet> removeList = GetGenreSetFromSelection(genreSet);
            newList.RemoveAll(item => removeList.Contains(item));
            currentGenreList = newList;
        }

        /// <summary>
        /// Replace the current list of genres with those found in the genreSet.
        /// </summary>
        /// <param name="genreSet">The HashSet of GameGenre objects.</param>
        public void ReplaceGenreCriteria(HashSet<GameGenre> genreSet)
        {
            List<GameSet> newList = new List<GameSet>(currentGenreList);
            newList.RemoveRange(0, newList.Count);
            newList.AddRange(GetGenreSetFromSelection(genreSet));
            currentGenreList = newList;
        }

        /// <summary>
        /// Remove all of the games that match the genres passed in.  These
        /// genres may not be in the current list (i.e. they may have been
        /// pulled in from some other match.  For example, a game that matches
        /// Luck but is also a Strategy game.  If Strategy is passed in, that
        /// game will be removed.
        /// </summary>
        /// <param name="genreSet">The HashSet of GameGenre objects.</param>
        public void ExcludeGenreCriteria(HashSet<GameGenre> genreSet)
        {
            // TODO(Optional) -- decide how to exclude a particular
            // Note that this is not quite like the others.  These represent a
            // separate set of games to be removed and will need to be treated
            // differently than the currentGenreList.
            throw new NotImplementedException("The Exclude Genre option is not yet implemented");
        }

        private List<GameSet> GetGenreSetFromSelection(HashSet<GameGenre> genreFlags)
        {
            List<GameSet> list = new List<GameSet>();

            foreach (GameGenre g in genreFlags)
            {
                list.Add(gameCriteria[g.ToString()]);
            }

            return list;
        }
    }
}
