using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class EnemyParticles : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem particlesPrefab;

        
        public void PlayParticles()
        {
            Instantiate(particlesPrefab, transform.position, Quaternion.identity);
        }
    }
}