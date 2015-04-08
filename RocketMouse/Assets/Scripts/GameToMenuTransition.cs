using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GameToMenuTransition : MonoBehaviour {
	void Start() {
		AdsManager.instance.HideBanner();
		Application.LoadLevel("Title");
	}
}