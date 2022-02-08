using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class GameSelectorConsole
    {
        GameSelector selector;
        public GameSelectorConsole(string filename)
        {
            selector = new GameSelector(filename);
        }

        public void SelectGame()
        {
            while (GetUserCriteria())
            {
                DisplayGames(selector.RetrieveCurrentMatches());
            }
        }

        private bool GetUserCriteria()
        {
            char selection = GetCriteriaSelected();
            switch (selection)
            {
                // TODO add the other criteria
                case 'G':
                {
                    UpdateGenreCriteria();
                } break;
                case 'C':
                {
                    ClearSelections();
                } break;
                case 'Q':
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearSelections()
        {
            selector.ClearGenreCriteria();
        }

        private char GetCriteriaSelected()
        {
            string instructions = "Enter the criteria that you would like to add/modfy, or 'Q' to quit.";
            string menu = "D) Difficulty\n"
                        + "G) Genre\n"
                        + "M) Media\n"
                        + "P) Maxumum Players\n"
                        + "T) Time\n"
                        + "C) Clear\n"
                        + "Q) Quit";
            string values = "DGMPTCQ";

            return GetValidatedSelection(instructions, menu, values);
        }

        private void DisplayGames(GameSet games)
        {
            Console.WriteLine("{0,-40}{1,-10}{2,-11}{3,-6}{4,-10}", "Game", "Media", "Difficulty", "Time", "Genre(s)");
            foreach (Game g in games)
            {
                string genres = "";
                foreach (GameGenre s in g.GenreList)
                    genres += s + ":";
                Console.Write("{0,-40}{1,-10}{2,5}{3,9}   {4}", g.Name, g.Media, g.Difficulty, g.AverageTime, genres.Trim(':'));
                Console.WriteLine();
            }
        }

        private void UpdateGenreCriteria()
        {
            char selection = GetUpdateActionSelection();
            switch (selection)
            {
                case 'A':
                {
                    string instructions = "Select Genre(s) to add to current list";
                    string genreSelection = GetGenreSelections(instructions);
                    selector.AddGenreCriteria(GetGameGenresFromSelection(genreSelection));
                } break;
                case 'D':
                {
                    string instructions = "Select Genre(s) to remove current list";
                    string genreSelection = GetGenreSelections(instructions);
                    selector.RemoveGenreCriteria(GetGameGenresFromSelection(genreSelection));
                } break;
                case 'R':
                {
                    string instructions = "Select Genre(s) to replace current list";
                    string genreSelection = GetGenreSelections(instructions);
                    selector.ReplaceGenreCriteria(GetGameGenresFromSelection(genreSelection));
                } break;
                case 'E':
                {
                    // TODO; optional
                    throw new NotImplementedException("The Exclude Genre option is not yet implemented");
                } break;
                case 'C':
                {
                    // nothing to do;
                } break;
            }
        }

        private char GetUpdateActionSelection()
        {
            string instructions = "Would you like to add or exclude or replace the current genre(s)?";
            string menu = "A) Add\n"
                        + "D) Delete\n"
                        + "E) Exclude\n"
                        + "R) Replace\n"
                        + "C) Cancel";
            string values = "ADERC";
            return GetValidatedSelection(instructions, menu, values);
        }

        private string GetGenreSelections(string instructions)
        {
            string genreMenu = "L) Luck\n"
                             + "S) Strategy\n"
                             + "D) Diplomacy\n"
                             + "K) Knowledge\n"
                             + "X) Dexterity";
            string genreOptions = "LSDKX";

          return GetMenuMultiSelection(instructions, genreMenu, genreOptions);

        }

        private string GetMenuSelection(string instructions, string menu)
        {
            string selection;
            Console.WriteLine(instructions);
            Console.WriteLine(menu);
            selection = Console.ReadLine().ToUpper();
            return selection;
        }

        private char GetValidatedSelection(string instructions, string menu, string allowedInput)
        {
            char input = ' ';
            string selection = GetMenuSelection(instructions, menu);
            if (selection.Length > 0)
                input = selection[0];

            while (!allowedInput.ToUpper().Contains(input))
            {
                Console.WriteLine("Invalid Entry");
                selection = GetMenuSelection(instructions, menu);
                if (selection.Length > 0)
                    input = selection[0];
            }

            return input;
        }

        private string GetMenuMultiSelection(string instructions, string menu, string allowedInput)
        {
            string selection;
            selection = GetMenuSelection(instructions, menu);

            while (!IsValidMultiSelect(allowedInput.ToUpper(), selection))
            {
                Console.WriteLine("Invalid Entry");
                selection = GetMenuSelection(instructions, menu);
            }

            return selection;
        }

        private bool IsValidMultiSelect(string options, string userInput)
        {
            if (userInput.Length == 0)
                return false;

            string[] selectionList = userInput.Split(',');
            foreach (string selection in selectionList)
            {
                if (!options.Contains(selection))
                    return false;
            }
            return true;
        }

        private HashSet<GameGenre> GetGameGenresFromSelection(string genreSelection)
        {
            HashSet<GameGenre> set = new HashSet<GameGenre>();
            string[] selectionList = genreSelection.Split(',');
            foreach (string genre in selectionList)
            {
                switch (genre)
                {
                    case "L": set.Add(GameGenre.Luck); break;
                    case "S": set.Add(GameGenre.Strategy); break;
                    case "D": set.Add(GameGenre.Diplomacy); break;
                    case "K": set.Add(GameGenre.Knowledge); break;
                    case "X": set.Add(GameGenre.Dexterity); break;
                    default: set.Add(GameGenre.NONE); break; // unreached
                }
            }
            return set;
        }
    }
}
