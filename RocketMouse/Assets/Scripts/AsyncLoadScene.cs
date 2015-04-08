using UnityEngine;
using UnityEngine.UI;
using System;

public class AsyncLoadScene : MonoBehaviour {
	public Image BarFill;
	public Text LoadingText;
	private AsyncOperation asyncOperation;
	
	void Start() {
		asyncOperation = Application.LoadLevelAsync("RocketMouse");
	}

	void Update() {
		float fillAmount = asyncOperation.progress / .9f;
		BarFill.fillAmount = fillAmount;
	}
}
