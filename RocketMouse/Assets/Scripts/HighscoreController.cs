using UnityEngine;
using UnityEngine.UI;
using System;

public class HighscoreController : MonoBehaviour {
	public Text HighScoreText;
	private static int highscore;

	// Use this for initialization
	void Awake () {
		highscore = PersistentData.GetHighscore();
		HighScoreText.text = "Best: " + String.Format("{0:n0}", highscore);
	}

	public static int GetHighscore() {
		return highscore;
	}
}
