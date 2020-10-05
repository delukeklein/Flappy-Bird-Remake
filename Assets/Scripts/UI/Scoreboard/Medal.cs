using Flappy.Bird.States;
using Flappy.Events;

using UnityEngine;
using UnityEngine.UI;


namespace Flappy.UI.Scoreboard
{
    [RequireComponent(typeof(Image))]
    public class Medal : MonoBehaviour, IDeathEvent
    {
        [SerializeField] private Score score;

        [SerializeField] private Sprite[] medals;

        private Image image;

        void Start()
        {
            image = GetComponent<Image>();

            EventSystem.Active.AddListener<IDeathEvent>(this, (e) => e.OnDeath());
        }

        public void OnDeath()
        {
            int index = (int)Mathf.Clamp(score.Value / 20f, 0f, medals.Length - 1f);

            image.sprite = medals[index];
        }

    }
}
