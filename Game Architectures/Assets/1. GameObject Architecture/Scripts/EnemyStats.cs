using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class EnemyStats : Stats
    {
        [field: SerializeField]
        private int scoreValue;

        public int Score { get => scoreValue; private set => scoreValue = value; }

        private void Awake()
        {
            CurrentHealth = Health;
        }

        public override void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            RaiseHealthChangedEvent();
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            RaiseDeathEvent();
            Destroy(gameObject);
            AudioManager.Instance.PlaySound("deathSFX");
        }
    }
}