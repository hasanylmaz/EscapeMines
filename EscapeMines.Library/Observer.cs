using EscapeMines.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Library
{
    public class Observer
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Board _board;

        public Observer(Board board)
        {
            _width = board.Width;
            _height = board.Height;
            _board = board;
        }

        public State Observe(Point position)
        {
            if (IsExit(position)) return State.IsExit;
            else if (IsDead(position)) return State.IsDead;
            else if (IsOutOfBounds(position)) return State.IsOutOfBounds;
            else if (IsDanger(position)) return State.IsDanger;
            else return State.Normal;
        }

        public bool IsDanger(Point position)
        {
            var adjacentPoints = GetAdjacentPositions(position);
            return adjacentPoints.Any(x => _board[position] is Mine);
        }

        private bool IsDead(Point position)
        {
            return _board[position] is Mine;
        }

        private bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.X >= _height || position.Y < 0 || position.Y >= _width;
        }

        private bool IsExit(Point position)
        {
            return _board[position] is Exit;
        }

        private List<Point> GetAdjacentPositions(Point position)
        {
            var list = new List<Point>();

            if (position.X - 1 >= 0) list.Add(new Point { X = position.X - 1, Y = position.Y });
            if (position.X - 1 >= 0 && position.Y - 1 >= 0) list.Add(new Point { X = position.X - 1, Y = position.Y - 1 });
            if (position.X - 1 >= 0 && position.Y + 1 < _width) list.Add(new Point { X = position.X - 1, Y = position.Y + 1 });
            if (position.X + 1 < _height) list.Add(new Point { X = position.X + 1, Y = position.Y });
            if (position.X + 1 < _height && position.Y - 1 >= 0) list.Add(new Point { X = position.X + 1, Y = position.Y - 1 });
            if (position.X + 1 < _height && position.Y + 1 < _width) list.Add(new Point { X = position.X + 1, Y = position.Y + 1 });
            if (position.Y - 1 >= 0) list.Add(new Point { X = position.X, Y = position.Y - 1 });
            if (position.Y + 1 < _width) list.Add(new Point { X = position.X, Y = position.Y + 1 });

            return list;
        }
    }
}
