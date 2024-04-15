using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Architectures.ScriptableObjects
{
    public class UIHealthbar : MonoBehaviour
    {
        [SerializeField]
        private Image healthBar;

        [SerializeField]
        private StatsSO playerStats;

        public void UpdateHealthbar()
        {
            float value = playerStats.CurrentHealth / playerStats.Health;
            healthBar.fillAmount = value;
        }
    }
}