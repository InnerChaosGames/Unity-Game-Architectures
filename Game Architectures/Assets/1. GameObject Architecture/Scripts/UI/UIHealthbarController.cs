using Architectures.GameObjectComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Architectures.GameObjectComponent
{
    public class UIHealthbarController : MonoBehaviour
    {
        [SerializeField]
        private Image healthbarImage = null;

        private PlayerStats boundPlayerStats;

        public void Bind(IHaveStats playerStats)
        {
            if (boundPlayerStats != null)
            {
                boundPlayerStats.HealthChanged -= HandleHealthChanged;
            }

            boundPlayerStats = (PlayerStats)playerStats;

            if (boundPlayerStats != null)
            {
                boundPlayerStats.HealthChanged += HandleHealthChanged;
                HandleHealthChanged(boundPlayerStats.CurrentHealth, boundPlayerStats.Health);
            }
            else
            {
                HandleHealthChanged(0, 1);
            }
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            print(healthPercentage);
            healthbarImage.fillAmount = healthPercentage;
        }
    }
}