using UnityEngine;
using UnityEngine.UI;

namespace Flappy.UI.Scoreboard
{
    [RequireComponent(typeof(Text))]
    public class ScoreToText : MonoBehaviour
    {
        [SerializeField] private Score score;

        private Text text;

        void Start()
        {
            text = GetComponent<Text>();
        }

        void Update()
        {
            text.text = score.Value.ToString();
        }
    }
}
