using System.Collections;
using System.Collections.Generic;
using Runner_Example;
using UnityEngine;

namespace Runner_Example {
    public class Collectable : IPoolableMonoBehaviour {
        private void OnTriggerEnter(Collider collider) {
            var gameSettings = GameSettings.Singleton;
            if (collider.CompareTag(gameSettings.despawnerTag)) {
                Despawn();
            }
            else if(collider.CompareTag(gameSettings.playerTag)) {
                var body = collider.attachedRigidbody;
                var playerController = body.GetComponent<PlayerController>();
                playerController.OnCollected();
                Despawn();
            }
        }

        private void Despawn() {
            OnDespawnSignal?.Invoke();
        }
    }
}

