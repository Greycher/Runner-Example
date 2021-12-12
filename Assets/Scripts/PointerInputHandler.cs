using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runner_Example {
    public class PointerInputHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler,
        IPointerUpHandler {
        [SerializeField] private PlayerController playerController;

        private const int NullPointerId = Int32.MinValue;

        private int _currentPointerId = NullPointerId;

        public void OnPointerDown(PointerEventData eventData) {
            if (_currentPointerId != NullPointerId) {
                return;
            }

            _currentPointerId = eventData.pointerId;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (eventData.pointerId != _currentPointerId) {
                return;
            }

            var diff = eventData.position - eventData.pressPosition;
            Vector2 input;
            if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y)) {
                input = Vector2.right * Mathf.Sign(diff.x);
            }
            else {
                input = Vector2.up * Mathf.Sign(diff.y);
            }

            playerController.Move(input);
        }

        public void OnDrag(PointerEventData eventData) { }

        public void OnPointerUp(PointerEventData eventData) {
            if (eventData.pointerId != _currentPointerId) {
                return;
            }

            _currentPointerId = NullPointerId;
        }
    }
}
