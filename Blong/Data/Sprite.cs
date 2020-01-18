using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blong.Data
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Sprite_(computer_graphics)
    /// </summary>
    public class Sprite
    {
        public int Top { get; set; }
        public int Left { get; set; }

        public double Direction { get; set; }
        public double Speed { get; set; }

        public TimerCallback Update { get; set; }

    }
}
