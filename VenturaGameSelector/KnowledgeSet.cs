using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class KnowledgeSet : GameSet
    {
        public override void AddIfFitsCriteria(Game game)
        {
            if (game.GenreList.Contains(GameGenre.Knowledge))
            {
                base.AddIfFitsCriteria(game);
            }
        }
    }
}
