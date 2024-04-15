using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        private List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();

        public void Raise(T data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(data);
            }
        }

        public void RegisterListener(GameEventListener<T> listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(GameEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}