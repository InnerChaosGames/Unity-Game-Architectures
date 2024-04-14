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
        [SerializeField]
        private InputReader input;

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

        private IHaveStats playerStats;

        private IObjectPool<Projectile> projectilePool;

        private float shootTime;

        private void OnEnable()
        {
            input.FireEvent += FireProjectile;
        }

        private void OnDisable()
        {
            input.FireEvent -= FireProjectile;
        }

        private void Awake()
        {
            playerStats = GetComponent<IHaveStats>();

            projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, DestroyPooledObject, true, defaultCapacity, maxSize);
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
            //projectile.Init(playerStats.Damage, projectilePool);
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