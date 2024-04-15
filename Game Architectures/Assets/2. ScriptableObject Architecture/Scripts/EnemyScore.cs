using Architectures.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class EnemyScore : MonoBehaviour
    {
        [SerializeField]
        private IntGameEvent updateScore;

        [SerializeField]
        private int scoreValue;

        private StatsManager statsManager;

        private void Awake()
        {
            statsManager = GetComponent<StatsManager>();
            statsManager.OnDeath += UpdateEnemyScore;
        }

        public void UpdateEnemyScore()
        {
            updateScore?.Raise(scoreValue);
        }
    }
}