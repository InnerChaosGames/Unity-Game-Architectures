using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class GameManager : MonoBehaviour
    {
        private int currentScore;
        private bool isPlaying;

        public event Action<int> ScoreChanged;
        public event Action<bool> GameOver;

        public int Score { get => currentScore; }
        public bool IsPlaying { get => isPlaying; }

        private EnemySpawner spawner;
        private PlayerStats playerStats;

        private void Awake()
        {
            spawner = GetComponent<EnemySpawner>();
            spawner.OnEnemyDied += UpdateScore;
        }

        private void Start()
        {
            isPlaying = true;
            playerStats = spawner.PlayerTransform.GetComponent<PlayerStats>();
            playerStats.OnDeath += OnPlayerDeath;
        }

        private void OnPlayerDeath(Stats obj)
        {
            isPlaying = false;
            GameOver?.Invoke(isPlaying);
        }

        private void UpdateScore(int score)
        {
            currentScore += score;
            ScoreChanged?.Invoke(currentScore);
        }
    }
}