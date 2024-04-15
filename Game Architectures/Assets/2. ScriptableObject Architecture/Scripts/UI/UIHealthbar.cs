using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Architectures.ScriptableObjects
{
    public class UIHealthbar : MonoBehaviour
    {
        [Header("Scriptable Object")]
        [SerializeField]
        private StatsSO playerStats;

        [Header("Settings")]
        [SerializeField]
        private Image healthBar;

        private int currentHealth;

        private void Start()
        {
            UpdateHealthbar(playerStats.Health);
            currentHealth = playerStats.Health;
        }

        public void UpdateHealthbar(int currentHealth)
        {
            float value = (float)currentHealth / (float)playerStats.Health;
            healthBar.fillAmount = value;
        }
    }
}