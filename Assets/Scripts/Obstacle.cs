using UnityEngine;

namespace Runner_Example {
    public class Obstacle : IPoolableMonoBehaviour{
        private void OnTriggerEnter(Collider collider) {
            var gameSettings = GameSettings.Singleton;
            if (collider.CompareTag(gameSettings.despawnerTag)) {
                Despawn();
            }
            else if(collider.CompareTag(gameSettings.playerTag)) {
                var body = collider.attachedRigidbody;
                var playerController = body.GetComponent<PlayerController>();
                playerController.Die();
            }
        }

        private void Despawn() {
            OnDespawnSignal?.Invoke();
        }
    }
}