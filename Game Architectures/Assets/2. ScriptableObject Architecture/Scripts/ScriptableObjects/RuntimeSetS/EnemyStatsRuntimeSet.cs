using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Runtime Sets/Stats", fileName = "Stats Runtime Set", order = 1)]
    public class EnemyStatsRuntimeSet : RuntimeSetSO<StatsManager>
    {
        public void RemoveAll()
        {
            Items.Clear();
        }
    }
}