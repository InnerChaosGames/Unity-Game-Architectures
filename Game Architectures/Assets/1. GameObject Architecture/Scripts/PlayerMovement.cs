using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 3;

        private PlayerInput playerInput;
        private Rigidbody2D rb;

        private Vector3 movement;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
            movement = new Vector2(playerInput.Horizontal, playerInput.Vertical);
            rb.velocity = movement.normalized * Time.fixedDeltaTime * speed;
        }
    }
}