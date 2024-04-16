using Architectures.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class EnemySounds : MonoBehaviour
    {
        [SerializeField]
        private AudioManagerSO audioManager;

        private StatsManager statsManager;

        private void Awake()
        {
            statsManager = GetComponent<StatsManager>();
            statsManager.OnDeath += PlaySound;
        }

        public void PlaySound()
        {
            audioManager.PlaySFXClip("deathSFX", transform.position);
        }
    }
}