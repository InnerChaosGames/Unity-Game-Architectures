using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architectures.ServiceLocatorArchitecture
{
    public sealed class ProjectBootstrapper : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private string mainSceneName = "SL_Main";
        [SerializeField] private bool loadUIScene = true;
        [SerializeField] private string uiSceneName = "SL_UIScene";

        [Header("Service Settings")]
        [SerializeField] private AudioServiceConfigSO audioServiceConfig;

        /// <summary>
        /// Uncomment RuntimeInitializeOnLoadMethod attribute to load the bootstrap scene before the active scene.
        /// With this, the game will always start from Bootstrap, no matter which scene you press Play from.
        /// </summary>
        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            string activeScene = "";
            
            #if UNITY_EDITOR
                var currentlyLoadedEditorScene = SceneManager.GetActiveScene();
                activeScene = currentlyLoadedEditorScene.name;
            #else
                activeScene = mainSceneName;
            #endif
            
            if (SceneManager.GetSceneByName("Bootstrap").isLoaded != true)
                SceneManager.LoadScene("Bootstrap");

            if (!string.IsNullOrEmpty(activeScene) && activeScene != "Bootstrap")
            {
                var op = SceneManager.LoadSceneAsync(activeScene, LoadSceneMode.Additive);
        
                op.completed += (_) => {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(activeScene));
                };
            }
        }

        private void Awake()
        {
            RegisterServices();
        }
      

        private IEnumerator Start()
        {
            ServiceLocator.Get<IScoreService>().Reset();
            ServiceLocator.Get<IGameStateService>().StartGame();

            if (loadUIScene)
            {
                yield return LoadSceneAdditive(uiSceneName);
            }
        }

        private void OnDestroy()
        {
            ServiceLocator.Clear();
        }

        private void RegisterServices()
        {
            ServiceLocator.Clear();

            ServiceLocator.Register<IScoreService>(new ScoreService());
            ServiceLocator.Register<IGameStateService>(new GameStateService());
            ServiceLocator.Register<IPlayerStateService>(new PlayerStateService());
            ServiceLocator.Register<IEnemyRegistryService>(new EnemyRegistryService());
            ServiceLocator.Register<IAudioService>(new AudioService(audioServiceConfig));
        }

        private static IEnumerator LoadSceneAdditive(string sceneName)
        {
            if (string.IsNullOrWhiteSpace(sceneName))
            {
                yield break;
            }

            if (SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                yield break;
            }

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (operation is { isDone: false })
            {
                yield return null;
            }
        }
    }
}
