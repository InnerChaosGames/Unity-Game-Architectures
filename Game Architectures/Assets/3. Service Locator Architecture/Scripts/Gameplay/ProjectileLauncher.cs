using UnityEngine;
using UnityEngine.Pool;

namespace Architectures.ServiceLocatorArchitecture
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private Transform projectileSpawnPos;
        [SerializeField] private float projectileForce = 300f;
        [SerializeField] private float shootDelay = 0.2f;
        [SerializeField] [Min(1)] private int defaultCapacity = 16;
        [SerializeField] [Min(1)] private int maxSize = 64;

        private PlayerInput _input;
        private Stats _playerStats;
        private IObjectPool<Projectile> _projectilePool;
        private IAudioService _audioService;
        private float _shootTime;

        private void Awake()
        {
            _playerStats = GetComponent<Stats>();
            _input = GetComponent<PlayerInput>();
            _input.OnFire += FireProjectile;

            ServiceLocator.TryGet(out _audioService);

            _projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledProjectile, true, defaultCapacity, maxSize);
        }

        private void OnDestroy()
        {
            if (_input != null)
            {
                _input.OnFire -= FireProjectile;
            }
        }

        private void FireProjectile()
        {
            if (Time.time < _shootTime + shootDelay)
            {
                return;
            }

            Projectile projectile = _projectilePool.Get();
            projectile.transform.SetPositionAndRotation(projectileSpawnPos.position, projectileSpawnPos.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileForce);
            projectile.Shoot();
            _audioService?.PlaySound("shootSFX");
            _shootTime = Time.time;
        }

        private Projectile CreateProjectile()
        {
            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPos.position, projectileSpawnPos.rotation);
            projectile.Init(_playerStats.Damage, _projectilePool);
            return projectile;
        }

        private static void OnGetFromPool(Projectile projectile)
        {
            projectile.gameObject.SetActive(true);
        }

        private static void OnReleaseToPool(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        private static void OnDestroyPooledProjectile(Projectile projectile)
        {
            Destroy(projectile.gameObject);
        }
    }
}
