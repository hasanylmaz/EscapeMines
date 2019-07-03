using EscapeMines.Library.Models;
using EscapeMines.Library.ReadModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Library
{
    public class FileReader
    {
        private static FileReader _fileReader;
        private FileReader() { }
        public static FileReader Instance()
        {
            return _fileReader ?? (_fileReader = new FileReader());
        }

        public SettingModel GetSettings()
        {
            var settingString = File.ReadAllLines("..\\..\\Settings\\settings.txt");
            var settings = new SettingModel();

            //first line of setting
            var sizeStrings = settingString[0].Split(' ');
            int.TryParse(sizeStrings[0], out var sizeX);
            int.TryParse(sizeStrings[1], out var sizeY);
            settings.Size = new Point(sizeX, sizeY);

            //second line of setting
            var minePointStrings = settingString[1].Split(' ');            
            foreach (var item in minePointStrings)
            {
                var minePoint = item.Split(',');
                int.TryParse(minePoint[0], out var mineX);
                int.TryParse(minePoint[1], out var mineY);
                settings.MinePoints.Add(new Point(mineX, mineY));
            }

            //third line of setting
            var exitPointStrings = settingString[2].Split(' ');
            int.TryParse(exitPointStrings[0], out var exitX);
            int.TryParse(exitPointStrings[1], out var exitY);
            settings.ExitPoint = new Point(exitX, exitY);

            //fourth line of setting
            var startPositionStrings = settingString[3].Split(' ');
            int.TryParse(startPositionStrings[0], out var posX);
            int.TryParse(startPositionStrings[1], out var posY);
            settings.StartPoint = new Point(posX, posY);
            settings.Direction = startPositionStrings[2];

            //fifth line of setting
            settings.Moves = settingString[4].Split(' ');
            
            return settings;
        }
    }
}
