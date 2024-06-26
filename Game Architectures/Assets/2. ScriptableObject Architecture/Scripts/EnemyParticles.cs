using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class EnemyParticles : MonoBehaviour
    {
        [SerializeField]
        private VFXManagerSO vfxManager;
        [SerializeField]
        private string deathVFX;

        private StatsManager statsManager;

        private void Awake()
        {
            statsManager = GetComponent<StatsManager>();
            statsManager.OnDeath += PlayParticles;
        }

        public void PlayParticles()
        {
            vfxManager.PlaySFXClip(deathVFX, transform.position);
        }
    }
}