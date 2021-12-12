using System;
using UnityEngine;

namespace Runner_Example {
    [CreateAssetMenu(menuName = "Game Settings")]
    public class GameSettings : ScriptableObject {
        public float platformLength;
        [TagSelector] public string playerTag;
        [TagSelector] public string despawnerTag;
        public SceneSettings sceneSettings;
        
        public const int LaneCount = 3;

        public static GameSettings Singleton {
            get {
                if (_instance == null) {
                    _instance = Resources.Load<GameSettings>(nameof(GameSettings));
                    if (_instance == null) {
                        Debug.LogError($"There must be {nameof(GameSettings)} object inside a Resources folder!");
                    }
                }

                return _instance;
            }
        }
        
        private static GameSettings _instance;
        
        [Serializable]
        public struct SceneSettings {
            public int mainMenuSceneIndex;
            public int gameSceneIndex;
            public int gameOverSceneIndex;
        }
    }
}