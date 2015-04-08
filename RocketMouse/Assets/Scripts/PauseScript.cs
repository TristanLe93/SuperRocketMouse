using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
	public CanvasGroup ScorePanel;
	public CanvasGroup PauseCanvas;
	public Button PauseButton;

	public void ShowPausedPanel() {
		PauseCanvas.alpha = 1;
		PauseCanvas.interactable = true;
		PauseButton.interactable = false;
		ScorePanel.interactable = false;

		Time.timeScale = 0f;
	}

	public void HidePausedPanel() {
		PauseCanvas.alpha = 0;
		PauseCanvas.interactable = false;
		PauseButton.interactable = true;
		ScorePanel.interactable = true;

		Time.timeScale = 1f;
	}

	public void ExitApplication() {
		Application.Quit();
	}

	public void LoadTitleMenu() {
		Application.LoadLevel("GameToMenuScene");
	}
}
