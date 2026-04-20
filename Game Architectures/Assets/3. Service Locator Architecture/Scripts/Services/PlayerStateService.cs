using System;

namespace Architectures.ServiceLocatorArchitecture
{
    public sealed class PlayerStateService : IPlayerStateService
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

        public event Action<int, int> OnHealthChanged;

        public void SetHealth(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;

            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        }

        public void Reset()
        {
            CurrentHealth = 0;
            MaxHealth = 0;

            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        }
    }
}
