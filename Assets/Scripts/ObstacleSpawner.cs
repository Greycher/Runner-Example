using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runner_Example {
    public class ObstacleSpawner : MonoBehaviour {
        [SerializeField] private Transform obstacleParent;
        [SerializeField] private Obstacle obstaclePrefab;
        [SerializeField] private float minCooldown = 0.5f;
        [SerializeField] private float maxCooldown = 1.5f;
        [SerializeField, Range(0, 1)] private float doubleSpawnProbability = 0.4f;

        private MonoBehaviourPool<Obstacle> _obstaclePool;
        private float _cooldown;

        private void Awake() {
            _obstaclePool = new MonoBehaviourPool<Obstacle>(obstaclePrefab);
        }

        private void Update() {
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0) {
                var probability = Random.Range(0f, 1f);
                if (probability <= doubleSpawnProbability) {
                    DoubleSpawn();
                }
                else {
                    Spawn();
                }
                _cooldown = Random.Range(minCooldown, maxCooldown);
            }
        }

        private void Spawn() {
            var laneCount = GameSettings.LaneCount;
            var rndLaneIndex = Random.Range(0, laneCount);
            SpawnAtLane(rndLaneIndex);
        }

        private void DoubleSpawn() {
            var gap = Random.Range(0, 2);
            var startLaneIndex = 0;
            if (gap == 0) {
                startLaneIndex = Random.Range(0, 2);
            }

            SpawnAtLane(startLaneIndex);
            SpawnAtLane(startLaneIndex + gap);
        }

        private void SpawnAtLane(int laneIndex) {
            var localSpawnPos = new Vector3(Utility.LaneIndexToPosX(laneIndex), 0, 0);
            var pos = transform.TransformPoint(localSpawnPos);
            var obstacle = _obstaclePool.Spawn();
            var tr = obstacle.transform;
            tr.position = pos;
            tr.rotation = Quaternion.identity;
            tr.SetParent(obstacleParent);
        }
    }
}

