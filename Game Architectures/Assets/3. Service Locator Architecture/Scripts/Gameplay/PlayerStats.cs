using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class PlayerStats : Stats
    {
        private IPlayerStateService _playerStateService;

        protected override void Awake()
        {
            base.Awake();
            CurrentHealth = Health;
            ServiceLocator.TryGet(out _playerStateService);
            _playerStateService?.SetHealth(CurrentHealth, Health);
        }

        public override void TakeDamage(int damage)
        {
            CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
            _playerStateService?.SetHealth(CurrentHealth, Health);

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            RaiseDeathEvent();
            Destroy(gameObject);
        }
    }
}
