using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class ComputerMedia : GameSet
    {
        public override void AddIfFitsCriteria(Game game)
        {
            if (game.Media.Equals(GameMedia.Computer))
            {
                base.AddIfFitsCriteria(game);
            }
        }
    }
}
