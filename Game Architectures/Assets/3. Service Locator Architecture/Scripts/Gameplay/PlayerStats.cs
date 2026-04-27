using System;
using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class PlayerStats : Stats
    {
        private IPlayerStateService _playerStateService;
        private IGameStateService _gameStateService;

        protected override void Awake()
        {
            base.Awake();
            CurrentHealth = Health;
        }

        private void Start()
        {
            _playerStateService = ServiceLocator.Get<IPlayerStateService>();
            _gameStateService = ServiceLocator.Get<IGameStateService>();
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
            _gameStateService.GameOver();
            Destroy(gameObject);
        }
    }
}
