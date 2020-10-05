using Flappy.Bird.States;
using Flappy.Events;

namespace Flappy.UI
{
    public class FadeOnStart : Fader, IStartEvent
    {
        new void Start()
        {
            base.Start();

            EventSystem.Active.AddListener<IStartEvent>(this, (e) => e.OnStart());
        }

        public void OnStart()
        {
            StartCoroutine(FadeCoroutine());
        }
    }
}
