using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Threading;
using System.Threading.Tasks;
using Blong.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Features;

namespace Blong.Services
{
    public class GameManager
    {
        public List<Sprite> Sprites = new List<Sprite>();
        public Box Bounds = null;
        private Timer _timer;
        public void AddSprite(Sprite sprite)
        {
            Sprites.Add(sprite);
        }
        public void Awake()
        {
            _timer = new Timer(
                callback: Update,
                state: Sprites,
                dueTime: 250,
                period: 250);
        }

        private void Update(object timerState)
        {
            var sprites = timerState as List<Sprite>;

            CheckOutOfBounds(sprites);
            DetectCollisions(sprites);
    
            foreach (var sprite in sprites)
            {
                sprite.Update(sprite);
            }

        }

        private void CheckOutOfBounds(List<Sprite> sprites)
        {
            if (Bounds == null) return;

            foreach (var sprite in sprites)
            {
                if (sprite.OutOfBounds != null) // does it handle OOB?
                {
                    if (sprite.Box.Top < Bounds.Top ||
                        sprite.Box.Bottom > Bounds.Bottom ||
                        sprite.Box.Left < Bounds.Left ||
                        sprite.Box.Right > Bounds.Right )
                    {
                        sprite.OutOfBounds(Bounds);
                    }
                }
            }
        }

        private void DetectCollisions(List<Sprite> sprites)
        {
            // look for box overlaps
            foreach (var sprite in sprites)
            {
                if (sprite.Collide != null) // does it handle collisions?
                {
                    var target = Colliding(sprite, sprites);
                    if (target != null)
                    {
                        sprite.Collide(target);
                    }
                }
            }
        }

        /// <summary>
        /// https://developer.mozilla.org/en-US/docs/Games/Techniques/2D_collision_detection
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="sprites"></param>
        /// <returns></returns>
        private Sprite Colliding(Sprite sprite, List<Sprite> sprites)
        {
            foreach (var target in sprites)
            {
                if(target.Id.Equals(sprite.Id)) continue; // ignore self

                var rect1 = sprite.Box;
                var rect2 = target.Box;

                if (rect1.Left < rect2.Left + rect2.Width &&
                    rect1.Left + rect1.Width > rect2.Left &&
                    rect1.Top < rect2.Top + rect2.Height &&
                    rect1.Top + rect1.Height > rect2.Top)
                {
                    return target;
                }
            }

            return null;
        }


        public void PauseGame() { }

        public void RestartGame()
        {
            Sprites = new List<Sprite>();
        }
    }

}
