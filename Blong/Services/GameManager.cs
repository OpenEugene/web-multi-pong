using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blong.Data;

namespace Blong.Services
{
    public class GameManager
    {
        private List<Sprite> _sprites = new List<Sprite>();
        private Timer _timer;
        public void AddSprite(Sprite sprite)
        {
            _sprites.Add(sprite);
        }
        public void Awake()
        {
            _timer = new Timer(
                callback: Update,
                state: _sprites,
                dueTime: 1000,
                period: 2000);
        }

        private void Update(object timerState)
        {
            var sprites = timerState as List<Sprite>;
            foreach (var sprite in sprites)
            {
                var left = sprite.Left;
                Interlocked.Decrement(ref left);
                sprite.Left = left;
                //sprite.Component.StateHasChanged();
            }

            ///Interlocked.Increment(ref state.Counter);

        }

       
        public void PauseGame() { }
        public void RestartGame() { }
    }

    //class TimerState
    //{
    //    public int Counter;
    //}
}
