using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Architectures.ScriptableObjects
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float lifeSpan = 3f;

        private int damage;
        private Rigidbody2D rb;
        private IObjectPool<Projectile> objectPool;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Init(int damage, IObjectPool<Projectile> pool)
        {
            this.damage = damage;
            this.objectPool = pool;
        }

    
        public void Shoot()
        {
            StartCoroutine(Deactivate());
        }

        private IEnumerator Deactivate()
        {
            yield return new WaitForSeconds(lifeSpan);

            rb.velocity = Vector3.zero;

            objectPool.Release(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                var other = collision.GetComponent<StatsManager>();

                if (other != null)
                {
                    other.TakeDamage(damage);
                }
                rb.velocity = Vector3.zero;
                StopAllCoroutines();
                try
                {
                    objectPool.Release(this);
                }
                catch
                {

                }
            }
        }

    }
}