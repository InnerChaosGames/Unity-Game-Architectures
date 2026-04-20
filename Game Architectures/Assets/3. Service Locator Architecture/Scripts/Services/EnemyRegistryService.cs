using System;
using System.Collections.Generic;

namespace Architectures.ServiceLocatorArchitecture
{
    public sealed class EnemyRegistryService : IEnemyRegistryService
    {
        private readonly HashSet<EnemyStats> _enemies = new();

        public IReadOnlyCollection<EnemyStats> Enemies => _enemies;
        public int Count => _enemies.Count;

        public event Action<EnemyStats> OnEnemyRegistered;
        public event Action<EnemyStats> OnEnemyUnregistered;

        public void Register(EnemyStats enemy)
        {
            if (enemy == null)
            {
                return;
            }

            if (_enemies.Add(enemy))
            {
                OnEnemyRegistered?.Invoke(enemy);
            }
        }

        public void Unregister(EnemyStats enemy)
        {
            if (enemy == null)
            {
                return;
            }

            if (_enemies.Remove(enemy))
            {
                OnEnemyUnregistered?.Invoke(enemy);
            }
        }

        public void Clear()
        {
            _enemies.Clear();
        }
    }
}