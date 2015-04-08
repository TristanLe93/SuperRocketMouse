using UnityEngine;
using UnityEngine.UI;

public class SpeedGaugeScript : MonoBehaviour {
	public Image BarImage;
	public Text CurrentSpeedText;
	public MouseController ControllerScript;

	private int minValue;
	private int maxValue;
	private int currentLevel;

	public AudioSource levelUpSound;


	void Start () {
		minValue = 0;
		maxValue = ControllerScript.currentDistanceTier;
		currentLevel = 1;
		CurrentSpeedText.text = currentLevel.ToString();
	}


	void Update () {
		UpdateBar();
	}

	void UpdateBar() {
		int currentScore = DistanceScoreManager.GetDistanceScore();
		float barPercent = (float)(currentScore - minValue) / (maxValue - minValue);

		BarImage.fillAmount = barPercent;
	}

	public void UpdateNextTier() {
		currentLevel++;

		CurrentSpeedText.text = currentLevel.ToString();

		minValue = maxValue;
		maxValue = ControllerScript.currentDistanceTier;

		levelUpSound.Play();
	}
}
