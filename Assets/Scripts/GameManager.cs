using UnityEngine;

namespace Runner_Example {
    public class GameManager : MonoBehaviour {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private ScoreUpdater scoreUpdater;
        [SerializeField] private int scoreCoefficient = 10;

        private void Awake() {
            playerController.OnCollectSignal += OnCollected;
            playerController.OnDieSignal = Utility.LoadGameOverScene;
            PersistentData.score = 0;
        }

        private void OnCollected() {
            PersistentData.score += scoreCoefficient;
            scoreUpdater.UpdateScore(PersistentData.score);
        }

        public static class PersistentData {
            public static int score;
        }
    }
}