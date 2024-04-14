using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverScreen;

        private GameManager boundGameManager;

        public void Bind(GameManager gameManager)
        {
            if (boundGameManager != null)
            {
                boundGameManager.GameOver -= HandleScoreChanged;
            }

            boundGameManager = gameManager;

            if (boundGameManager != null)
            {
                boundGameManager.GameOver += HandleScoreChanged;
                HandleScoreChanged(boundGameManager.IsPlaying);
            }
        }

        private void HandleScoreChanged(bool isPlaying)
        {
            gameOverScreen.SetActive(!isPlaying);
        }
    }
}