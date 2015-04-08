using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	private static int score;
	private static Text text;

	void Awake () {
		text = GetComponent<Text>();
		score = 0;
		text.text = score.ToString();
	}

	public static void UpdateScore() {
		score++;
		text.text = score.ToString();
	}

	public static int GetCoinsScore() {
		return score;
	}
}
