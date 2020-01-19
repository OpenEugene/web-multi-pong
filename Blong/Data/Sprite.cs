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
        public double Direction { get; set; } = 0;  //down
        public int Speed { get; set; } = 0;

        public TimerCallback Render { get; set; }


        #region Physics & Math

        public Action<Sprite> Collide { get; set; }
       
        public Action<Box> OutOfBounds { get; set; }
        public void MoveBox()
        {
            Box.Top += Convert.ToInt32(Vx);
            Box.Left += Convert.ToInt32(Vy);
        }
        
        public Guid Id = Guid.NewGuid();
        public double Vx => (Speed) * Math.Cos(ConvertToRadians(Direction));
        public double Vy => (Speed) * Math.Sin(ConvertToRadians(Direction));
        
        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        public double ConvertToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }

        #endregion

        #region Free/Busy and Debounce

        public int DebounceCount { get; set; } = 0;
        private bool _isBusy = false; // stop event storms
        public void Debounce(int count)
        {
            // up the number of updates to skip accepting events
            DebounceCount+= count;
        }

        public void Bounce()
        {
            // burn down the debounce.
            if(DebounceCount>0) DebounceCount--;
        }

        public bool Debounced()
        {
            return DebounceCount < 1;
        }

        public void Free()
        {
            _isBusy = false;
        }

        public void Busy()
        {
            _isBusy = true;
        }

        public bool IsFree => !_isBusy & Debounced();

        #endregion
    }
}
