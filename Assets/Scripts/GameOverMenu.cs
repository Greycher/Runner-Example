using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner_Example {
    public class GameOverMenu : MonoBehaviour {
        [SerializeField] private Button playAgainButton;
        [SerializeField] private Text scoreTextField;
        [SerializeField] private string scoreFormat = "Score: {0}";


        private void Awake() {
            playAgainButton.onClick.AddListener(Utility.LoadGameScene);
            scoreTextField.text = String.Format(scoreFormat, GameManager.PersistentData.score);
        }
    }
}
