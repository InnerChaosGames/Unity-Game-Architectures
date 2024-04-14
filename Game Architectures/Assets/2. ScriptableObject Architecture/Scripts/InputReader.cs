using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Architectures.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Input/Input Reader", fileName = "Input Reader")]
    public class InputReader : ScriptableObject, InputActions.IGameplayActions
    {
        [SerializeField]
        private InputActionAsset asset;

        public event UnityAction<Vector2> MoveEvent;
        public event UnityAction<Vector2> AimEvent;
        public event UnityAction FireEvent;

        private InputActions actions;


        private void OnEnable()
        {
            if(actions == null)
            {
                actions = new InputActions();
                actions.Gameplay.SetCallbacks(this);
            }

            actions.Enable();
        }

        private void OnDisable()
        {
            actions.Disable();
        }

        void InputActions.IGameplayActions.OnMove(InputAction.CallbackContext context)
        {
            //Debug.Log("Moved");
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        void InputActions.IGameplayActions.OnFire(InputAction.CallbackContext context)
        {
            if (FireEvent != null && context.started)
            {
                FireEvent?.Invoke();
            }
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            AimEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }
}