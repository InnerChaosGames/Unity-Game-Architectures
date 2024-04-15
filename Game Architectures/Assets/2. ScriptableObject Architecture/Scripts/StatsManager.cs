using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField]
    StatsSO stats;
    [SerializeField]
    private GameEventSO damageTake;

    private void Awake()
    {
        stats.DeathEvent += PlayerDied;
    }

    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);
    }

    private void PlayerDied()
    {

    }
}
