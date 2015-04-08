using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {
	public void FadeOut() {
		this.gameObject.SetActive(false);
	}

	public void FadeIn() {
		this.gameObject.SetActive(true);
	}

	public void RestartLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
