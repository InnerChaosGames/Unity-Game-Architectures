using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyPrefab;
        [SerializeField] private float spawnDelay = 10f;
        [SerializeField] private Vector2Int minMaxSpawnPerWave = new(1, 8);
        [SerializeField] private Vector2 minMaxWidth = new(-10f, 10f);
        [SerializeField] private Vector2 minMaxHeight = new(-6f, 6f);

        private Transform _playerTransform;
        private IGameStateService _gameStateService;
        private float _currentTime;

        private void Awake()
        {
            PlayerMovement player = FindFirstObjectByType<PlayerMovement>();
            _playerTransform = player != null ? player.transform : null;
            ServiceLocator.TryGet(out _gameStateService);
        }

        private void Start()
        {
            Invoke(nameof(SpawnWave), 1f);
        }

        private void Update()
        {
            if (_gameStateService != null && _gameStateService.IsPlaying == false)
            {
                return;
            }

            if (Time.time < _currentTime + spawnDelay)
            {
                return;
            }

            SpawnWave();
            _currentTime = Time.time;
        }

        private void SpawnWave()
        {
            if (_playerTransform == null || enemyPrefab == null)
            {
                return;
            }

            int spawnCount = Random.Range(minMaxSpawnPerWave.x, minMaxSpawnPerWave.y + 1);

            for (int index = 0; index < spawnCount; index++)
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemy.Init(_playerTransform);
            }
        }

        private Vector2 GetRandomSpawnPosition()
        {
            int direction = Random.Range(0, 4);

            return direction switch
            {
                0 => new Vector2(minMaxWidth.x, Random.Range(minMaxHeight.x, minMaxHeight.y)),
                1 => new Vector2(minMaxWidth.y, Random.Range(minMaxHeight.x, minMaxHeight.y)),
                2 => new Vector2(Random.Range(minMaxWidth.x, minMaxWidth.y), minMaxHeight.x),
                _ => new Vector2(Random.Range(minMaxWidth.x, minMaxWidth.y), minMaxHeight.y)
            };
        }
    }
}
