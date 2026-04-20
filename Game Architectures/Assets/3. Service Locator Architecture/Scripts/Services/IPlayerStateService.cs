using System;

namespace Architectures.ServiceLocatorArchitecture
{
    public interface IPlayerStateService
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }

        event Action<int, int> OnHealthChanged;

        void SetHealth(int currentHealth, int maxHealth);
        void Reset();
    }
}
