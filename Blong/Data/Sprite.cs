﻿using System;
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
        public double Direction { get; set; } = 0;
        public int Speed { get; set; } = 0;

        public TimerCallback Update { get; set; }


        #region Physics & Math
        public Action<Sprite> Collide { get; set; }
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


       
    }
}
