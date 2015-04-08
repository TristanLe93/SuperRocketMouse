using UnityEngine;
using UnityEngine.UI;
using System;

public class ScorePanelScript : MonoBehaviour {
	public Animator RetryButtonAnimator;
	public CanvasGroup scorePanel;

	public Text ScoreText;
	public Text DistanceText;
	public Text BonusRawText;
	public Text BestScoreText;
	
	private int finalScore;
	private float tempScore;
	private float incrementRate;
	private int highscore;

	private bool scoreDone = false;

	void FixedUpdate() {
		// increment the score every update
		if (scorePanel.interactable && tempScore <= finalScore && !scoreDone) {
			tempScore += incrementRate;

			if (tempScore > finalScore) {
				tempScore = finalScore;
				scoreDone = true;
				RetryButtonAnimator.enabled = true;
				AdsManager.instance.ShowInterstitital();
			}

			// set the score
			int theScore = (int)tempScore;
			ScoreText.text = String.Format("{0:n0}", theScore);

			if (tempScore > highscore)
				BestScoreText.text = "A New High Score!!";
		}
	}

	public void ShowScorePanel(int coinsScore, int distanceScore) {
		// calculate final score
		float multiplier = (coinsScore / 100f);
		int bonusScore = (int)(distanceScore * multiplier);
		finalScore = distanceScore + bonusScore;

		// set text to UIText elements
		DistanceText.text = String.Format("{0:n0}", distanceScore) + "m";
		BonusRawText.text = String.Format("{0:n0}", bonusScore);

		highscore = HighscoreController.GetHighscore();

		// determine the increment rate for each update
		incrementRate = finalScore / 30f;

		// show the UIPanel
		scorePanel.alpha = 1;
		scorePanel.interactable = true;

		// save highscore if it is beaten
		if (finalScore > highscore)
			PersistentData.SetHighscore(finalScore);
	}
}
