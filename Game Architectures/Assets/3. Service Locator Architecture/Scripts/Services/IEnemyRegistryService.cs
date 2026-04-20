using System;
using System.Collections.Generic;

namespace Architectures.ServiceLocatorArchitecture
{
    public interface IEnemyRegistryService
    {
        IReadOnlyCollection<EnemyStats> Enemies { get; }
        int Count { get; }

        event Action<EnemyStats> OnEnemyRegistered;
        event Action<EnemyStats> OnEnemyUnregistered;

        void Register(EnemyStats enemy);
        void Unregister(EnemyStats enemy);
        void Clear();
    }
}