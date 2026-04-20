using System;
using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public abstract class Stats : MonoBehaviour
    {
        [Header("Initial Stats")]
        [SerializeField] StatsSO initialStats;
        [Header("Runtime")]
        [SerializeField] private string statsName;
        [SerializeField] [Min(1)] private int health = 10;
        [SerializeField] [Min(0)] private int damage = 1;

        public string Name => statsName;
        public int Health => health;
        public int CurrentHealth { get; protected set; }
        public int Damage => damage;

        public event Action<Stats> OnDeath;

        public abstract void TakeDamage(int damage);

        protected virtual void Awake()
        {
            statsName = initialStats.Name;
            health = initialStats.Health;
            damage = initialStats.Damage;
        }

        protected void RaiseDeathEvent()
        {
            OnDeath?.Invoke(this);
        }
    }
}
