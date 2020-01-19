using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blong.Data
{
    public class Box
    {
        public int Top { get; set; } = 0;
        public int Left { get; set; } = 0;
        public int Height { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Right => Left + Width;
        public int Bottom => Top + Height;

    }
}
