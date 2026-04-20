using UnityEngine;

namespace Architectures.ServiceLocatorArchitecture
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 6f;

        private PlayerInput _playerInput;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void FixedUpdate()
        {
            Vector2 movement = new Vector2(_playerInput.Horizontal, _playerInput.Vertical);
            _rb.linearVelocity = movement.normalized * speed;
        }
    }
}
