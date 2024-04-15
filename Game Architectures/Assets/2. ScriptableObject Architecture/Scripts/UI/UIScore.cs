using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        private int currentScore = 0;

        public void UpdateScore(int score)
        {
            currentScore += score;
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}