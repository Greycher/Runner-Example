using UnityEngine;
using UnityEngine.UI;

namespace Runner_Example {
    public class MainMenu : MonoBehaviour {
        [SerializeField] private Button playButton;

        private void Awake() {
            playButton.onClick.AddListener(Utility.LoadGameScene);
        }
    }
}

