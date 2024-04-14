using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class UIScoreController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        private GameManager boundGameManager;

        public void Bind(GameManager gameManager)
        {
            if (boundGameManager != null)
            {
                boundGameManager.ScoreChanged -= HandleScoreChanged;
            }

            boundGameManager = gameManager;

            if (boundGameManager != null)
            {
                boundGameManager.ScoreChanged += HandleScoreChanged;
                HandleScoreChanged(boundGameManager.Score);
            }
        }

        private void HandleScoreChanged(int score)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}