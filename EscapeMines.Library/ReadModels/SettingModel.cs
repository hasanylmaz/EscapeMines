using EscapeMines.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Library.ReadModels
{
    public class SettingModel
    {
        public Point Size { get; set; }
        public List<Point> MinePoints { get; set; } = new List<Point>();
        public Point ExitPoint { get; set; }
        public Point StartPoint { get; set; }
        public string Direction { get; set; }
        public string[] Moves { get; set; }
    }
}
