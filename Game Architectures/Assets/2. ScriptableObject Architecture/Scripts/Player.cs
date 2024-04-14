using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private InputReader input;

        [SerializeField]
        private Transform gunPivot;


        [SerializeField]
        private float speed;

        private Rigidbody2D rb;
        private Vector3 movement;
        private Vector2 mousePos;
        private Camera camera;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            camera = Camera.main;
            input.MoveEvent += OnMove;
        }

        private void OnEnable()
        {
            input.MoveEvent += OnMove;
            input.AimEvent += OnAim;
        }

        private void OnDisable()
        {
            input.MoveEvent -= OnMove;
            input.AimEvent -= OnAim;
        }

        private void OnAim(Vector2 pos)
        {
            mousePos = pos;
        }

        private void OnMove(Vector2 move)
        {
            movement = move;
        }

        private void Update()
        {
            Vector2 dir = camera.ScreenToWorldPoint(mousePos) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gunPivot.rotation = rotation;
        }

        private void FixedUpdate()
        {
            rb.velocity = movement.normalized * Time.fixedDeltaTime * speed;
        }
    }
}