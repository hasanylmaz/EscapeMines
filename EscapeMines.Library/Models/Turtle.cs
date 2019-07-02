using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Library.Models
{
    public class Turtle : Element
    {
        private static Turtle _turtle;
        private Turtle(Point position) { Position = position; }
        public static Turtle Instance(Point position)
        {
            return _turtle ?? (_turtle = new Turtle(position));
        }

        public Directions Direction { get; set; }

        public void Move()
        {
            switch (Direction)
            {
                case Directions.N:
                    Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X - 1, Y = _turtle.Position.Y });
                    _turtle.Position = new Point { X = _turtle.Position.X - 1, Y = _turtle.Position.Y };
                    break;
                case Directions.S:
                    Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X + 1, Y = _turtle.Position.Y });
                    _turtle.Position = new Point { X = _turtle.Position.X + 1, Y = _turtle.Position.Y };
                    break;
                case Directions.E:
                    Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X, Y = _turtle.Position.Y + 1 });
                    _turtle.Position = new Point { X = _turtle.Position.X, Y = _turtle.Position.Y + 1 };
                    break;
                case Directions.W:
                    Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X, Y = _turtle.Position.Y - 1 });
                    _turtle.Position = new Point { X = _turtle.Position.X, Y = _turtle.Position.Y - 1 };
                    break;
            }
        }

        public void Rotate()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    Printer.Print(Direction);
                    break;
                case Directions.S:
                    Direction = Directions.W;
                    Printer.Print(Direction);
                    break;
                case Directions.E:
                    Direction = Directions.S;
                    Printer.Print(Direction);
                    break;
                case Directions.W:
                    Direction = Directions.N;
                    Printer.Print(Direction);
                    break;
                default:
                    break;
            }
        }
    }
}
