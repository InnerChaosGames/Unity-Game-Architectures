using UnityEngine;
using UnityEngine.UI;

namespace Architectures.ServiceLocatorArchitecture
{
    public class UIPlayerHealthbar : MonoBehaviour
    {
        [SerializeField] private Image healthbarImage;

        private IPlayerStateService _playerStateService;

        private void OnEnable()
        {
            _playerStateService = ServiceLocator.Get<IPlayerStateService>();
            _playerStateService.OnHealthChanged += HandleHealthChanged;
        }

        private void OnDisable()
        {
            _playerStateService.OnHealthChanged -= HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
            if (healthbarImage == null)
            {
                return;
            }

            print("Health changed");
            
            healthbarImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
