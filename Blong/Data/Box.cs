using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blong.Data
{
    public class Box
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Right => Left + Width;
        public int Bottom => Top + Height;

    }
}
