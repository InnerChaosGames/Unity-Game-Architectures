using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private UIHealthbarController healthbarController;
        [SerializeField]
        private UIScoreController scoreController;
        [SerializeField]
        private UIGameOver gameOver;

        private void Start()
        {
            healthbarController.Bind(UILoader.PlayerStats);
            scoreController.Bind(UILoader.GameManager);
            gameOver.Bind(UILoader.GameManager);
        }
    }
}