using System;
using UnityEngine;

namespace Runner_Example {
    public class PlayerMotor : MonoBehaviour {
        [SerializeField] private Rigidbody body;
        [SerializeField] private float maxXSpeed = 10;
        private Vector3 _targetPos;

        private void Awake() {
            _targetPos = transform.position;
        }
        
        private void FixedUpdate() {
            var position = transform.position;
            position.z = _targetPos.z;
            position.x = Mathf.MoveTowards(position.x, _targetPos.x, maxXSpeed * Time.fixedDeltaTime);
            body.MovePosition(position);
        }

        public void Move(Vector3 position) {
            _targetPos = position;
        }
    }
}
