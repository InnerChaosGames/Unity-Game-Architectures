using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class EnemyStats : Stats
    {
        [SerializeField] [Min(0)] private int scoreValue = 1;

        private IEnemyRegistryService _enemyRegistryService;
        private IScoreService _scoreService;
        private IAudioService _audioService;

        public int Score => scoreValue;

        private void Awake()
        {
            CurrentHealth = Health;

            ServiceLocator.TryGet(out _enemyRegistryService);
            ServiceLocator.TryGet(out _audioService);
            ServiceLocator.TryGet(out _scoreService);
        }

        private void OnEnable()
        {
            _enemyRegistryService?.Register(this);
        }

        private void OnDisable()
        {
            _enemyRegistryService?.Unregister(this);
        }

        public override void TakeDamage(int damage)
        {
            CurrentHealth = Mathf.Max(0, CurrentHealth - damage);

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            RaiseDeathEvent();
            _scoreService?.AddScore(Score);
            _audioService?.PlaySound("deathSFX");
            Destroy(gameObject);
        }
    }
}