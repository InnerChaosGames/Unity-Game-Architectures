using System;
using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public sealed class GameStateService : IGameStateService
    {
        public bool IsGameOver { get; private set; }
        public bool IsPlaying => IsGameOver == false;

        public event Action<bool> OnGameOverStateChanged;

        public void StartGame()
        {
            IsGameOver = false;
            OnGameOverStateChanged?.Invoke(IsGameOver);
            Debug.Log(IsGameOver);
        }

        public void GameOver()
        {
            if (IsGameOver)
            {
                return;
            }

            IsGameOver = true;
            OnGameOverStateChanged?.Invoke(IsGameOver);
            Debug.Log(IsGameOver);
        }
    }
}
