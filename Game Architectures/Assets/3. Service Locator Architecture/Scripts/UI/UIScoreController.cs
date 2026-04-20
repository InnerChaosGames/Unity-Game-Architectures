using TMPro;
using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class UIScoreController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private IScoreService _scoreService;

        private void OnEnable()
        {
            _scoreService = ServiceLocator.Get<IScoreService>();
            _scoreService.OnScoreChanged += HandleScoreChanged;
        }

        private void OnDisable()
        {
            _scoreService.OnScoreChanged -= HandleScoreChanged;
        }

        private void HandleScoreChanged(int score)
        {
            if (scoreText == null)
            {
                return;
            }

            scoreText.text = $"Score: {score}";
        }
    }
}
