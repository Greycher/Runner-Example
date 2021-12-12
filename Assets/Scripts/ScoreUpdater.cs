using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runner_Example {
    public class ScoreUpdater : MonoBehaviour {
        [SerializeField] private Text textField;
        [SerializeField] private string scoreFormat = "Score: {0}";

        public void UpdateScore(int score) {
            textField.text = String.Format(scoreFormat, score);
        }
    }
}