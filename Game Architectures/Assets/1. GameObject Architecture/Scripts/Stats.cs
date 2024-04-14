using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public abstract class Stats : MonoBehaviour, IHaveStats
    {
        [field: SerializeField]
        public string Name { get; protected set; }

        [field: SerializeField]
        public int Health { get; protected set; }

        [field: SerializeField]
        public int CurrentHealth { get; protected set; }

        [field: SerializeField]
        public int Damage { get; protected set; }

        public abstract void TakeDamage(int damage);

        public event Action<Stats> OnDeath;
        public event Action<int, int> HealthChanged;

        protected void RaiseDeathEvent()
        {
            OnDeath?.Invoke(this);
        }

        protected void RaiseHealthChangedEvent()
        {
            HealthChanged?.Invoke(CurrentHealth, Health);
        }
    }
}