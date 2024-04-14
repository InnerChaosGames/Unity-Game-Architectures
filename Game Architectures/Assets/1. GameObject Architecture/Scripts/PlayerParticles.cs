using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class PlayerParticles : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem deathParticlesPrefab;

        private PlayerStats playerHealth;

        private void Awake()
        {
            playerHealth = GetComponent<PlayerStats>();
            playerHealth.OnDeath += HandlePlayerDeath;
        }

        private void OnDestroy()
        {
            playerHealth.OnDeath -= HandlePlayerDeath;
        }

        private void HandlePlayerDeath(Stats stats)
        {
            Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        }

    }
}