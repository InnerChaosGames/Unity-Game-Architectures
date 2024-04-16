using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Architectures.ScriptableObjects
{
    public class UIEnemyHealthbar : MonoBehaviour
    {
        [SerializeField]
        private Image healthBar;

        [SerializeField]
        private EnemyStatsRuntimeSet enemyStats;
        [SerializeField]
        private StatsSO stats;

        public void UpdateHealthBar()
        {
            int maxHealth = enemyStats.Items.Count * stats.Health;
            int currentHealth = 0;

            for (int i = 0; i < enemyStats.Items.Count; i++)
            {
                if (enemyStats.Items[i] != null)
                {
                    currentHealth += enemyStats.Items[i].CurrentHealth;
                }
            }

            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        }
    }
}