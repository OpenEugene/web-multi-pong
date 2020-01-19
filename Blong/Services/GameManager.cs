using System.Collections.Generic;
using System.IO.Enumeration;
using System.Threading;
using System.Threading.Tasks;
using Blong.Data;
using Microsoft.AspNetCore.Components;

namespace Blong.Services
{
    public class GameManager
    {
        public List<Sprite> Sprites = new List<Sprite>();
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
                dueTime: 500,
                period: 1000);
        }

        private void Update(object timerState)
        {
            var sprites = timerState as List<Sprite>;

            DetectCollisions(sprites);

            foreach (var sprite in sprites)
            {
                sprite.Update(sprite);
            }

        }

        private void DetectCollisions(List<Sprite> sprites)
        {
            // look at al the sprites
            foreach (var sprite in sprites)
            {
              
                
            }
        }


        public void PauseGame() { }

        public void RestartGame()
        {
            Sprites = new List<Sprite>();
        }
    }

    //class TimerState
    //{
    //    public int Counter;
    //}
}
