using Flappy.Bird.States;
using Flappy.Events;

using System.Collections;

using UnityEngine;


namespace Flappy.UI
{
    public interface IScoreboardEvent : IEventHandler
    {
        void OnScoreboard();
    }

    public class ScoreboardController : MonoBehaviour, IDeathEvent
    {
        [SerializeField] private Vector2 targetPosition;
        [SerializeField] private float movementSpeed;

        public void Start()
        {
            EventSystem.Active.AddListener<IDeathEvent>(this, (e) => e.OnDeath());
        }

        public void OnDeath()
        {
            StartCoroutine(MoveUp());
        }

        private IEnumerator MoveUp()
        {
            while (transform.position != (Vector3)targetPosition)
            {
                ((RectTransform)transform).position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);

                yield return new WaitForEndOfFrame();
            }

            EventSystem.Active.Execute<IScoreboardEvent>();

            yield return null;
        }
    }
}
