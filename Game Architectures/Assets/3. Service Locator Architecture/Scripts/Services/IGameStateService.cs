using System;

namespace Architectures.ServiceLocatorArchitecture
{
    public interface IGameStateService
    {
        bool IsGameOver { get; }
        bool IsPlaying { get; }

        event Action<bool> OnGameOverStateChanged;

        void StartGame();
        void GameOver();
    }
}
