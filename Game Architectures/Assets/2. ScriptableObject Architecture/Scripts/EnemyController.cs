using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        StatsSO enemyStats;

        [SerializeField]
        private float speed = 4;

        [SerializeField]
        private Transform player;


        public void Init(Transform playerTransform)
        {
            player = playerTransform;
        }

        private void Awake()
        {
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
                StatsManager stats = player.GetComponent<StatsManager>();
                stats.TakeDamage(enemyStats.Damage);
                Destroy(gameObject);
                AudioManager.Instance.PlaySound("deathSFX");
            }
        }
    }
}