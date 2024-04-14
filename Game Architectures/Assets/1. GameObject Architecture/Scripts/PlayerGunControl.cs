using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.GameObjectComponent
{
    public class PlayerGunControl : MonoBehaviour
    {
        [SerializeField]
        private Transform gunPivot;

        private PlayerInput playerInput;
        private Camera camera;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            camera = Camera.main;
        }

        private void Update()
        {
            Vector2 dir = camera.ScreenToWorldPoint(playerInput.MousePosition) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gunPivot.rotation = rotation;
        }
    }
}