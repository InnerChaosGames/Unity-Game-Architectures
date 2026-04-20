using UnityEngine;
using UnityEngine.UI;

namespace Architectures.ServiceLocatorArchitecture
{
    public class UIEnemyHealthbar : MonoBehaviour
    {
        [SerializeField] private Image healthbarImage;

        private IEnemyRegistryService _enemyRegistryService;
        private int _maxHealth;

        private void OnEnable()
        {
            _enemyRegistryService = ServiceLocator.Get<IEnemyRegistryService>();
            _enemyRegistryService.OnEnemyRegistered += HandleEnemyRegistered;
            _enemyRegistryService.OnEnemyUnregistered += HandleEnemyUnregistered;

            _maxHealth = 0;

            foreach (EnemyStats enemy in _enemyRegistryService.Enemies)
            {
                if (enemy == null)
                {
                    continue;
                }

                _maxHealth += enemy.Health;
            }

            UpdateHealth();
        }

        private void OnDisable()
        {
            if (_enemyRegistryService == null)
            {
                return;
            }

            _enemyRegistryService.OnEnemyRegistered -= HandleEnemyRegistered;
            _enemyRegistryService.OnEnemyUnregistered -= HandleEnemyUnregistered;
        }

        private void Update()
        {
            UpdateHealth();
        }

        private void HandleEnemyRegistered(EnemyStats enemy)
        {
            if (enemy == null)
            {
                return;
            }

            if (_enemyRegistryService.Count == 1)
            {
                _maxHealth = 0;
            }

            _maxHealth += enemy.Health;
            UpdateHealth();
        }

        private void HandleEnemyUnregistered(EnemyStats enemy)
        {
            if (_enemyRegistryService.Count == 0)
            {
                _maxHealth = 0;
            }

            UpdateHealth();
        }

        private void UpdateHealth()
        {
            if (healthbarImage == null)
            {
                return;
            }

            int currentHealth = 0;

            foreach (EnemyStats enemy in _enemyRegistryService.Enemies)
            {
                if (enemy == null)
                {
                    continue;
                }

                currentHealth += enemy.CurrentHealth;
            }

            healthbarImage.fillAmount = _maxHealth > 0
                ? (float)currentHealth / _maxHealth
                : 0f;
        }
    }
}