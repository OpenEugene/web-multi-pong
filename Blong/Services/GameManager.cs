using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blong.Data;

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
                period: 100);
        }

        private void Update(object timerState)
        {
            var sprites = timerState as List<Sprite>;
            foreach (var sprite in sprites)
            {
                sprite.Update(sprite);
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
