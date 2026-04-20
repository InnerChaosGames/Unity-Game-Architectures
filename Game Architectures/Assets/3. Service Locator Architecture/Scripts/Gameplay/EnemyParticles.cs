using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class EnemyParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem deathParticles;

        private EnemyStats _enemyStats;

        private void Awake()
        {
            _enemyStats = GetComponent<EnemyStats>();
            _enemyStats.OnDeath += HandleEnemyDeath;
        }

        private void OnDestroy()
        {
            if (_enemyStats != null)
            {
                _enemyStats.OnDeath -= HandleEnemyDeath;
            }
        }

        private void HandleEnemyDeath(Stats stats)
        {
            if (deathParticles == null)
            {
                return;
            }

            ParticleSystem particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
            particles.Play();
        }
    }
}
