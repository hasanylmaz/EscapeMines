using EscapeMines.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Library
{
    public static class Printer
    {

        public static string startString = "Starting Position of Turtle: ({x},{y}), Direction: {dir}";
        public static string movedFromTo = "Turtle moved from position {from} to {to}";
        public static string rotate = "Turned to {to}";
        public const string HitMine = "Our little turtle is hit the mine!";
        public const string Out = "Turtle went out of bounds";
        public const string IsNear = "Turtle is still in danger!";
        public const string Success = "Success";

        public static void Print(Point pointFrom, Point pointTo)
        {
            var combinePointFrom = $"({pointFrom.X},{pointFrom.Y})";
            var combinePointTo = $"({pointTo.X},{pointTo.Y})";
            var printText = movedFromTo.Replace("{from}", combinePointFrom).Replace("{to}", combinePointTo);
            Console.WriteLine(printText);
            Console.WriteLine(new string('-', 50));
        }

        public static void Print(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 50));
        }

        public static void Print(Directions dir)
        {
            Console.WriteLine(rotate.Replace("{to}", dir.ToString()));
            Console.WriteLine(new string('-', 50));
        }

        public static void Print(EscapeMines.Library.Models.Turtle turtle)
        {
            Console.WriteLine(startString.Replace("{x}", turtle.Position.X.ToString()).Replace("{y}", turtle.Position.Y.ToString()).Replace("{dir}", turtle.Direction.ToString()));
            Console.WriteLine(new string('-', 50));
        }
    }
}
