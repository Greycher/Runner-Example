using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner_Example {
    public class CollectableSpawner : MonoBehaviour {
        [SerializeField] private Transform collectableParent;
        [SerializeField] private Collectable collectablePrefab;
        [SerializeField] private float minCooldown = 2f;
        [SerializeField] private float maxCooldown = 4f;
        [SerializeField] private int minStreak = 3;
        [SerializeField] private int maxStreak = 7;
        [SerializeField] private float spacingZ = 0.3f;
        
        private MonoBehaviourPool<Collectable> _collectablePool;
        private float _cooldown;
        
        private void Awake() {
            _collectablePool = new MonoBehaviourPool<Collectable>(collectablePrefab);
        }

        private void Update() {
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0) {
                Spawn();
                _cooldown = Random.Range(minCooldown, maxCooldown);
            }
        }
        
        private void Spawn() {
            var laneCount = GameSettings.LaneCount;
            var rndLaneIndex = Random.Range(0, laneCount);
            SpawnAtLane(rndLaneIndex);
        }
        
        private void SpawnAtLane(int laneIndex) {
            var streak = Random.Range(minStreak, maxStreak);
            for (int i = 0; i < streak; i++) {
                var localSpawnPos = new Vector3(Utility.LaneIndexToPosX(laneIndex), 0, spacingZ * i);
                var pos = transform.TransformPoint(localSpawnPos);
                var obstacle = _collectablePool.Spawn();
                var tr = obstacle.transform;
                tr.position = pos;
                tr.rotation = Quaternion.identity;
                tr.SetParent(collectableParent);
            }
        }
    }
}

