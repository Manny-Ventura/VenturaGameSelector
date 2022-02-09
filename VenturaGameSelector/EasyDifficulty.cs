using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class EasyDifficulty : GameSet
    {
        public override void AddIfFitsCriteria(Game game)
        {
            GameDifficulty difficulty;
            if (game.Difficulty == 1)
            {
                difficulty = GameDifficulty.Low;
                base.AddIfFitsCriteria(game);
            }
        }
    }
}
