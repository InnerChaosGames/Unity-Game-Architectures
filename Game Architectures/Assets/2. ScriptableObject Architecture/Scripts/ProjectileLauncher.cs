using Architectures.GameObjectComponent;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Windows;

namespace Architectures.ScriptableObjects
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        [SerializeField]
        private InputReader input;
        [SerializeField]
        private StatsSO playerStats;

        [Header("Other Settings")]
        [SerializeField]
        private Projectile projectilePrefab;
        [SerializeField]
        private Transform projectileSpawnPos;
        [SerializeField]
        private float projectileForce = 300;

        [SerializeField]
        private float shootDelay = 0.2f;

        [SerializeField]
        private int defaultCapacity;
        [SerializeField]
        private int maxSize = 100;

        private IObjectPool<Projectile> projectilePool;

        private float shootTime;
        private bool isFiring;

        private void OnEnable()
        {
            input.FireEvent += OnProjectileButton;
        }

        private void OnDisable()
        {
            input.FireEvent -= OnProjectileButton;
        }

        private void Awake()
        {
            projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, DestroyPooledObject, true, defaultCapacity, maxSize);
        }

        private void OnProjectileButton(bool isFiring)
        {
            this.isFiring = isFiring;
        }

        private void Update()
        {
            if (isFiring)
            {
                FireProjectile();
            }
        }

        private void FireProjectile()
        {
            if (Time.time > shootTime + shootDelay)
            {
                Projectile projectile = projectilePool.Get();

                if (projectile == null)
                    return;

                projectile.transform.SetPositionAndRotation(projectileSpawnPos.position, projectileSpawnPos.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileForce);

               // projectile.Shoot();

                shootTime = Time.time;
            }
        }

        private Projectile CreateProjectile()
        {
            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPos.position, Quaternion.identity);
            projectile.Init(playerStats.Damage, projectilePool);
            return projectile;
        }

        private void OnGetFromPool(Projectile projectile)
        {
            projectile.gameObject.SetActive(true);
        }

        private void OnReleaseToPool(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        private void DestroyPooledObject(Projectile projectile)
        {
            Destroy(projectile.gameObject);
        }
    }
}