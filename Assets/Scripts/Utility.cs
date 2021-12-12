using UnityEngine.SceneManagement;

namespace Runner_Example {
    public static class Utility {
        public static float LaneIndexToPosX(int laneIndex) {
            var laneCount = GameSettings.LaneCount;
            var midLaneIndex = laneCount * 0.5f - 0.5f;
            var laneStep = GameSettings.Singleton.platformLength / laneCount;
            return laneStep * (laneIndex - midLaneIndex);
        }
        
        public static void LoadGameScene() {
            SceneManager.LoadScene(GameSettings.Singleton.sceneSettings.gameSceneIndex);
        }
        
        public static void LoadGameOverScene() {
            SceneManager.LoadScene(GameSettings.Singleton.sceneSettings.gameOverSceneIndex);
        }
    }
}