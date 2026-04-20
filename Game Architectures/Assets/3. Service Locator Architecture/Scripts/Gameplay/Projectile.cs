using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Architectures.ServiceLocatorArchitecture
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float lifeSpan = 3f;

        private Rigidbody2D _rb;
        private int _damage;
        private IObjectPool<Projectile> _objectPool;
        private Coroutine _lifeRoutine;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Init(int damage, IObjectPool<Projectile> objectPool)
        {
            _damage = damage;
            _objectPool = objectPool;
        }

        public void Shoot()
        {
            if (_lifeRoutine != null)
            {
                StopCoroutine(_lifeRoutine);
            }

            _lifeRoutine = StartCoroutine(DeactivateAfterDelay());
        }

        private IEnumerator DeactivateAfterDelay()
        {
            yield return new WaitForSeconds(lifeSpan);
            Release();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var other = collision.GetComponent<Stats>();

            if (other != null)
            {
                other.TakeDamage(_damage);
            }

            Release();
        }

        private void Release()
        {
            _rb.linearVelocity = Vector2.zero;

            if (_lifeRoutine != null)
            {
                StopCoroutine(_lifeRoutine);
                _lifeRoutine = null;
            }

            _objectPool?.Release(this);
        }
    }
}
