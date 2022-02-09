using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class MediumDifficulty : GameSet
    {
        public override void AddIfFitsCriteria(Game game)
        {
            GameDifficulty difficulty;
            if (game.Difficulty == 2)
            {
                difficulty= GameDifficulty.Medium;
                base.AddIfFitsCriteria(game);
            } 
        }
    }
}
