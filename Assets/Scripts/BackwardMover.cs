using UnityEngine;

namespace Runner_Example {
    public class BackwardMover : MonoBehaviour {
        [SerializeField] private Rigidbody body;
        [SerializeField] private float speed = 5;

        private void FixedUpdate() {
            var pos = transform.position;
            body.MovePosition(pos + Vector3.back * speed * Time.fixedDeltaTime); 
        }
    }
}
