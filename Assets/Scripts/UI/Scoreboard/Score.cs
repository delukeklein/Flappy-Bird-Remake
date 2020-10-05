using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy.UI.Scoreboard
{
    [CreateAssetMenu(fileName = "Score", menuName = "Score/Score", order = 1)]
    public class Score : ScriptableObject
    {
        public int Value;
    }
}
