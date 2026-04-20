using System;

namespace Architectures.ServiceLocatorArchitecture
{
    public interface IScoreService
    {
        int Score { get; }

        event Action<int> OnScoreChanged;

        void AddScore(int amount);
        void Reset();
    }
}
