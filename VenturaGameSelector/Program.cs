using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelectorStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSelectorConsole selector = new GameSelectorConsole("C:/Users/Fuzz/Desktop/GameList.txt");
            selector.SelectGame();
            Console.WriteLine("\nDone");
            Console.ReadLine();
        }
    }
}
