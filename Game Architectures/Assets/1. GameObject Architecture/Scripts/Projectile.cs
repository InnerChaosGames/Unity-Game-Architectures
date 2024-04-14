using Architectures.GameObjectComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Architectures.GameObjectComponent
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float lifeSpan = 3f;

        private Rigidbody2D rb;
        private int damage;
        private IObjectPool<Projectile> objectPool;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Init(int damage, IObjectPool<Projectile> objectPool)
        {
            this.damage = damage;
            this.objectPool = objectPool;
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
            var other = collision.GetComponent<IHaveStats>();

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