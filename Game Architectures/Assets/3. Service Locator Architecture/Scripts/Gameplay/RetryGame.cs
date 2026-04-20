using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architectures.ServiceLocatorArchitecture
{
    public class RetryGame : MonoBehaviour
    {
        [SerializeField] private string bootstrapSceneName = "BootstrapScene";

        public void ReloadGame()
        {
            SceneManager.LoadSceneAsync(bootstrapSceneName, LoadSceneMode.Single);
        }
    }
}
