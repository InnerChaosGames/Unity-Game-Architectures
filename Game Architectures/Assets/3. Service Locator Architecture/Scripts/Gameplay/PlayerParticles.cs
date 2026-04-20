using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class PlayerParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem deathParticlesPrefab;

        private PlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = GetComponent<PlayerStats>();
            _playerStats.OnDeath += HandlePlayerDeath;
        }

        private void OnDestroy()
        {
            if (_playerStats != null)
            {
                _playerStats.OnDeath -= HandlePlayerDeath;
            }
        }

        private void HandlePlayerDeath(Stats stats)
        {
            if (deathParticlesPrefab == null)
            {
                return;
            }

            Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        }
    }
}
