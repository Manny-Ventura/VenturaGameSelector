using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class BoardMedia : GameSet
    {
        public override void AddIfFitsCriteria(Game game)
        {
            if (game.Media.Equals(GameMedia.Board))
            {
                base.AddIfFitsCriteria(game);
            }
        }
    }
}