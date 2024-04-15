using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Events/Game Event", fileName = "Game Event")]
    public class GameEventSO : ScriptableObject
    {
        private List<VoidEventListener> listeners = new List<VoidEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(VoidEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(VoidEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}