using System.Collections.Generic;
using System.Threading;
using EscapeMines.Library.ReadModels;

namespace EscapeMines.Library.Models
{
    public class Game
    {
        private Point _turtleStartPoint;
        private readonly FileReader _fileReader;
        private readonly SettingModel _settings;
        private readonly Board _board;
        private readonly Observer _observer;

        private Game()
        {
            _fileReader = FileReader.Instance();
            _settings = _fileReader.GetSettings();
            _turtleStartPoint = _settings.StartPoint;
            _board = new Board(_settings.Size.Y, _settings.Size.X);
            _observer = new Observer(_board);
            Initialize();
        }

        public static Game CreateNewGame()
        {
            return new Game();
        }

        public void Start()
        {
            var moves = _settings.Moves;
            var turtle = _board[_turtleStartPoint] as Turtle;
            if (System.Enum.TryParse<Directions>(_settings.Direction, out var dir)) turtle.Direction = dir;
            Printer.Print(turtle);
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == "R") turtle.Rotate();
                else if (moves[i] == "M") turtle.Move();
                Thread.Sleep(1000);
                var situation = _observer.Observe(turtle.Position);
                if (situation == State.IsDead)
                {
                    Printer.Print(Printer.Dead);
                    break;
                }
                else if (situation == State.IsExit)
                {
                    Printer.Print(Printer.Success);
                    break;
                }
                else if (situation == State.IsOutOfBounds)
                {
                    Printer.Print(Printer.Out);
                }
                else if (situation == State.IsDanger)
                {
                    Printer.Print(Printer.IsNear);
                }
            }
        }

        private void Initialize()
        {
            SetTurtle(_turtleStartPoint);
            SetExit(_settings.ExitPoint);
            SetMines(_settings.MinePoints);
        }

        private void SetMines(List<Point> mines)
        {
            foreach (var minePosition in mines)
            {
                try
                {
                    _board[minePosition] = new Mine() { Position = minePosition };
                }
                catch
                {/*ignore*/ }
            }
        }

        private void SetExit(Point exitPosition)
        {
            try
            {
                _board[exitPosition] = new Exit() { Position = exitPosition };
            }
            catch
            {/*ignore*/}
        }

        private void SetTurtle(Point turtlePosition)
        {
            try
            {
                _board[turtlePosition] = Turtle.Instance(turtlePosition);
            }
            catch
            {/*ignore*/}
        }
    }
}
