using System;
using UnityEngine;

namespace Runner_Example {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private PlayerMotor motor;

        public Action OnCollectSignal;
        public Action OnDieSignal;
        
        private int _currentLaneIndex = 1;
        
        public void Move(Vector2 input) {
            var unclampedLaneIndex = Mathf.RoundToInt(_currentLaneIndex + input.x);
            _currentLaneIndex = Mathf.Clamp(unclampedLaneIndex, 0, GameSettings.LaneCount - 1);
            var pos = transform.position;
            pos.x = Utility.LaneIndexToPosX(_currentLaneIndex);
            motor.Move(pos);
        }

        public void Die() {
            OnDieSignal?.Invoke();
        }

        public void OnCollected() {
            OnCollectSignal?.Invoke();
        }
    }
}
