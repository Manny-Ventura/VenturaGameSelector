using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class HardDifficulty : GameSet
    {
        public override void AddIfFitsCriteria(Game game)
        {
            GameDifficulty difficulty;
            if (game.Difficulty == 3)
            {
                difficulty=GameDifficulty.High;
                base.AddIfFitsCriteria(game);
            }
        }
    }
}
