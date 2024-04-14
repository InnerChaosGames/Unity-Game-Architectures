using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architectures.GameObjectComponent
{
    public class RetryGame : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadSceneAsync("MainScene");
            SceneManager.UnloadSceneAsync("UIScene");
        }
    }
}