using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;

        private Transform _player;
        private EnemyStats _enemyStats;
        private IGameStateService _gameStateService;
        private IAudioService _audioService;

        public void Init(Transform playerTransform)
        {
            _player = playerTransform;
        }

        private void Awake()
        {
            _enemyStats = GetComponent<EnemyStats>();
            ServiceLocator.TryGet(out _gameStateService);
            ServiceLocator.TryGet(out _audioService);
        }

        private void Update()
        {
            if (_player == null)
            {
                return;
            }

            if (_gameStateService != null && _gameStateService.IsPlaying == false)
            {
                return;
            }

            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _player.position, step);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") == false)
            {
                return;
            }

            var stats = collision.GetComponent<Stats>();

            if (stats != null)
            {
                stats.TakeDamage(_enemyStats.Damage);
            }

            _audioService?.PlaySound("deathSFX");
            Destroy(gameObject);
        }
    }
}
