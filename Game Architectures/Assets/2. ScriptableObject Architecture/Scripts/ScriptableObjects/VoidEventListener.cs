using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Architectures.ScriptableObjects
{
    public class VoidEventListener : MonoBehaviour
    {
        [SerializeField]
        private GameEventSO Event;
        [SerializeField]
        private UnityEvent response;


        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnRegisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}