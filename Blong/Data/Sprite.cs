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
        
        public Box Box { get; set; }
        public int Direction { get; set; }
        public int Speed { get; set; }

        public TimerCallback Update { get; set; }
        public Guid Id = Guid.NewGuid();

    }
}
