using Flappy.Events;
using Flappy.Bird.States;

namespace Flappy.UI
{
    public class FadeOnDeath : Fader, IDeathEvent
    {
        new void Start()
        {
            base.Start();

            EventSystem.Active.AddListener<IDeathEvent>(this, (e) => e.OnDeath());
        }

        public void OnDeath()
        {
            StartCoroutine(FadeCoroutine());
        }
    }
}
