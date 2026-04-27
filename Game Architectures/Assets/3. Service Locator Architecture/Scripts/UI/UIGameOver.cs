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
            HandleGameStateChanged(_gameStateService.IsGameOver);
        }

        private void HandleGameStateChanged(bool IsGameOver)
        {
            if (gameOverScreen == null)
            {
                return;
            }
            

            gameOverScreen.SetActive(IsGameOver);
        }
    }
}
