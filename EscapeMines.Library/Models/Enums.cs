using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Library.Models
{
    public enum Directions
    {
        N,
        S,
        E,
        W
    }

    public enum State
    {
        IsDead,
        Normal,
        IsOutOfBounds,
        IsExit,
        IsDanger
    }
}
