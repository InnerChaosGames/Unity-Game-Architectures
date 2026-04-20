using System;

namespace Architectures.ServiceLocatorArchitecture
{
    public sealed class ScoreService : IScoreService
    {
        public int Score { get; private set; }

        public event Action<int> OnScoreChanged;

        public void AddScore(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            Score += amount;
            OnScoreChanged?.Invoke(Score);
        }

        public void Reset()
        {
            Score = 0;
            OnScoreChanged?.Invoke(Score);
        }
    }
}
