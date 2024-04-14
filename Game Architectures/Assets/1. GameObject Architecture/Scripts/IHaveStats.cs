using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public interface IHaveStats
    {
        public string Name { get; }
        public int Health { get; }
        public int CurrentHealth { get; }
        public int Damage { get; }

        public void TakeDamage(int damage);
    }
}