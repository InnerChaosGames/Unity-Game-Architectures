using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverScreen;

        private IGameStateService _gameStateService;

        private void OnEnable()
        {
            _gameStateService = ServiceLocator.Get<IGameStateService>();
            _gameStateService.OnGameOverStateChanged += HandleGameStateChanged;
            HandleGameStateChanged(_gameStateService.IsPlaying);
        }

        private void HandleGameStateChanged(bool IsGameRunning)
        {
            if (gameOverScreen == null)
            {
                return;
            }

            gameOverScreen.SetActive(IsGameRunning == false);
        }
    }
}
