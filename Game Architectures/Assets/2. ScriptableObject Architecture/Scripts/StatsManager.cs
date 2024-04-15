using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class StatsManager : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        [SerializeField]
        private StatsSO stats;
        [SerializeField]
        private IntGameEvent healthValueChanged;
        [SerializeField]
        private SimpleGameEvent onDeath;

        [field: SerializeField]
        public int CurrentHealth { get ; private set; }

        public event Action OnDeath;
        public StatsSO Stats { get => stats; }

        private void Awake()
        {
            CurrentHealth = stats.Health;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            healthValueChanged?.Raise(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
         
        private void Die()
        {
            OnDeath?.Invoke();
            onDeath?.Raise(null);
            Destroy(gameObject);
        }
    }
}