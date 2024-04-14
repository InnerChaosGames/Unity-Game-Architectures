using Architectures.GameObjectComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architectures.GameObjectComponent
{
    public class UILoader : MonoBehaviour
    {
        [SerializeField]
        private PlayerStats playerStats;
        [SerializeField]
        private GameManager gameManager;

        public static PlayerStats PlayerStats;

        public static GameManager GameManager;

        private void Awake()
        {
            PlayerStats = playerStats;
            GameManager = gameManager;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (SceneManager.GetSceneByName("UIScene").isLoaded == false)
            {
                SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
            }
        }
    }
}