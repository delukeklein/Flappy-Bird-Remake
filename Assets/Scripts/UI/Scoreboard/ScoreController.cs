using Flappy.Events;
using Flappy.Bird.States;

using UnityEngine;

namespace Flappy.UI.Scoreboard
{
    public class ScoreController : MonoBehaviour, IScoreHitBoxEvent, IDeathEvent
    {
        [SerializeField] private Score score;
        [SerializeField] private Score best;

        void Start()
        {
            score.Value = 0;

            best.Value = PlayerPrefs.GetInt("Best");

            EventSystem.Active.AddListener<IScoreHitBoxEvent>(this, (e) => e.OnScore());
            EventSystem.Active.AddListener<IDeathEvent>(this, (e) => e.OnDeath());
        }

        public void OnScore()
        {
            score.Value++;

            if (score.Value > best.Value)
            {
                best.Value = score.Value;
            }
        }

        public void OnDeath()
        {
            PlayerPrefs.SetInt("Best", best.Value);
            PlayerPrefs.Save();
        }
    }
}