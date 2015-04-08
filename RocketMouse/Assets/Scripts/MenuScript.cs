using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour {
	public Animator SettingsDialog;
	public Animator CreditsDialog;
	public Button PlayButton;
	public Text BestScoreText;

	void Awake() {
		Application.targetFrameRate = 60;
		Time.timeScale = 1f;

		int theScore = PersistentData.GetHighscore();
		BestScoreText.text = "Best: " + String.Format("{0:n0}", theScore);
	}

	public void StartGame() {
		Application.LoadLevelAsync("LoadingScene");
	}

	public void OpenSettings() {
		PlayButton.interactable = false;
		SettingsDialog.enabled = true;
		SettingsDialog.SetBool("isHidden", false);
	}

	public void CloseSettings() {
		PlayButton.interactable = true;
		SettingsDialog.SetBool("isHidden", true);
	}

	public void OpenCredits() {
		PlayButton.interactable = false;
		CreditsDialog.enabled = true;
		CreditsDialog.SetBool("isHidden", false);
	}
	
	public void CloseCredits() {
		PlayButton.interactable = true;
		CreditsDialog.SetBool("isHidden", true);
	}

	public void OpenRatingGooglePlayStore() {
		Application.OpenURL("http://play.google.com/store/apps/details?id=com.TristanLe.SuperRocketMouse");
	}

	public void QuitApplication() {
		Application.Quit();
	}
}
