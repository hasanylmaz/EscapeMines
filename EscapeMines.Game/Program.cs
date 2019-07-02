using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EscapeMines.Library;

namespace EscapeMines.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = EscapeMines.Library.Models.Game.CreateNewGame();
            game.Start();

            Thread.Sleep(60000);
            System.Console.ReadKey();
        }
    }
}
