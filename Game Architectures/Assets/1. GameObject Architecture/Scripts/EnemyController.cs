using Architectures.GameObjectComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private float speed = 4;

        [SerializeField]
        private Transform player;

        private IHaveStats enemyStats;


        public void Init(Transform playerTransform)
        {
            player = playerTransform;
        }

        private void Awake()
        {
            enemyStats = GetComponent<EnemyStats>();
        }

        private void Update()
        {
            if (player != null)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.position, step);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                IHaveStats stats = player.GetComponent<IHaveStats>();
                stats.TakeDamage(enemyStats.Damage);
                Destroy(gameObject);
                AudioManager.Instance.PlaySound("deathSFX");
            }
        }
    }
}