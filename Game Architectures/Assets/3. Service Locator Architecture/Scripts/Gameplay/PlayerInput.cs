using System;
using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    public class PlayerInput : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public bool FireWeapons { get; private set; }
        public Vector2 MousePosition { get; private set; }

        public event Action OnFire;

        private IGameStateService _gameStateService;

        private void Awake()
        {
            ServiceLocator.TryGet(out _gameStateService);
        }

        private void Update()
        {
            if (_gameStateService != null && _gameStateService.IsPlaying == false)
            {
                Horizontal = 0f;
                Vertical = 0f;
                FireWeapons = false;
                return;
            }

            MousePosition = Input.mousePosition;
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            FireWeapons = Input.GetButton("Fire1");

            if (FireWeapons)
            {
                OnFire?.Invoke();
            }
        }
    }
}
