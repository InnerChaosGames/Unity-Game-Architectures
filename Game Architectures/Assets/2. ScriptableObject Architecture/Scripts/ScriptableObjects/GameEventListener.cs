using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Architectures.ScriptableObjects
{
    public class GameEventListener<T> : MonoBehaviour
    {
        [SerializeField]
        private GameEvent<T> Event;
        [SerializeField]
        private UnityEvent<T> response;


        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnRegisterListener(this);
        }

        public void OnEventRaised(T data)
        {
            response.Invoke(data);
        }
    }
}