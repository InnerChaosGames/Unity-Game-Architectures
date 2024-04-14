using Architectures.GameObjectComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class EnemyParticles : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem deathParticles;

        private EnemyStats enemyStats;

        private void Awake()
        {
            enemyStats = GetComponent<EnemyStats>();
            enemyStats.OnDeath += HandleEnemyDeath;
        }

        private void OnDestroy()
        {
            enemyStats.OnDeath -= HandleEnemyDeath;
        }

        private void HandleEnemyDeath(Stats stats)
        {
            var particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
            particles.Play();
        }

    }
}