using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private IntGameEvent onDamagePlayer;
        [SerializeField]
        private Vector3VariableSO playerPosition;

        [SerializeField]
        private float speed = 4;

        private StatsManager statsManager;


        public void Init(Vector3VariableSO playerPos)
        {
            playerPosition = playerPos;
        }

        private void Awake()
        {
            statsManager = GetComponent<StatsManager>();
        }

        private void Update()
        {
            if (playerPosition != null)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, playerPosition.value, step);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                onDamagePlayer.Raise(statsManager.Stats.Damage);
                Destroy(gameObject);
            }
        }
    }
}