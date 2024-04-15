using Architectures.GameObjectComponent;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        [SerializeField]
        private Vector3VariableSO playerPosition;

        [Header("Other Settings")]
        [SerializeField]
        private EnemyController enemyPrefab;

        [SerializeField]
        private float spawnDelay = 10f;
        [SerializeField]
        private Vector2Int minMaxSpawnPerWave = new Vector2Int(1, 8);

        [SerializeField]
        private Vector2 minMaxWidth = new Vector2(-10, 10);
        [SerializeField]
        private Vector2 minMaxHeight = new Vector2(-6, 6);

        private float currentTime;

        private void Start()
        {
            // currentTime = Time.time - spawnDelay + 1;
            Invoke(nameof(SpawnWave), 1f);
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time >= currentTime + spawnDelay)
            {
                SpawnWave();
                currentTime = Time.time;
            }
        }

        private void SpawnWave()
        {
            int spawnCount = UnityEngine.Random.Range(minMaxSpawnPerWave.x, minMaxSpawnPerWave.y);
            print("Spawn");
            for (int i = 0; i < spawnCount; i++)
            {
                int direction = UnityEngine.Random.Range(0, 4);
                Vector2 spawnPos = Vector2.zero;

                switch (direction)
                {
                    case 0:
                        spawnPos = new Vector2(minMaxWidth.x, UnityEngine.Random.Range(minMaxHeight.x, minMaxHeight.y));
                        break;
                    case 1:
                        spawnPos = new Vector2(minMaxWidth.y, UnityEngine.Random.Range(minMaxHeight.x, minMaxHeight.y));
                        break;
                    case 2:
                        spawnPos = new Vector2(UnityEngine.Random.Range(minMaxWidth.x, minMaxWidth.y), minMaxHeight.x);
                        break;
                    case 3:
                        spawnPos = new Vector2(UnityEngine.Random.Range(minMaxWidth.x, minMaxWidth.y), minMaxHeight.y);
                        break;
                }

                var enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                enemy.Init(playerPosition);
                var enemyStats = enemy.GetComponent<EnemyStats>();
            }
        }
    }
}