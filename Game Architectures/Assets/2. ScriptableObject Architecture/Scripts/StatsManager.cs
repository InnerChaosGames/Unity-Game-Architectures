using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    StatsSO stats;

    private void Awake()
    {
        stats.DeathEvent += PlayerDied;
    }

    private void PlayerDied()
    {

    }
}
