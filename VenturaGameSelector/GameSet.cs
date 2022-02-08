using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class GameSet : HashSet<Game>
    {
        public virtual void AddIfFitsCriteria(Game game)
        {
            Add(game);
        }
    }
}
