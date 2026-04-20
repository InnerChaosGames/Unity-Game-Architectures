using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerGunControl : MonoBehaviour
    {
        [SerializeField] private Transform gunPivot;

        private Camera _camera;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_camera == null || gunPivot == null)
            {
                return;
            }

            Vector2 direction = _camera.ScreenToWorldPoint(_playerInput.MousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
