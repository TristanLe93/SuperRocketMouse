﻿using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour {
	private static AdsManager _instance;
	private BannerView bannerAd;
	private InterstitialAd interstitial;
	private int showInterstitialCounter;
	
	public static AdsManager instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<AdsManager>();
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}

	void Awake() {
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
		} else {
			if (this != _instance)
				Destroy(this.gameObject);
		}

		showInterstitialCounter = 5;
	}

	
	void Start () {
		InitialiseBannerAd();
		InitialiseInterstitialAd();
		RequestNewBannerAd();
		RequestNewInterstitialAd();
		HideBanner();
	}

	private void InitialiseBannerAd() {
		#if UNITY_EDITOR
			string adUnitId = "unused";
		#elif UNITY_ANDROID
			string adUnitId = "ca-app-pub-6804613073213226/3100815197";
		#else
			string adUnitId = "unexpected_platform";
		#endif

		bannerAd = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
	}

	private void InitialiseInterstitialAd() {
		#if UNITY_EDITOR
			string adUnitId = "unused";
		#elif UNITY_ANDROID
			string adUnitId = "ca-app-pub-6804613073213226/1624081996";
		#else
			string adUnitId = "unexpected_platform";
		#endif

		interstitial = new InterstitialAd(adUnitId);
		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.AdOpened += HandleInterstitial;
		interstitial.AdClosing += HandleInterstitial;
		interstitial.AdClosed += HandleInterstitial;
		interstitial.AdLeftApplication += HandleInterstitial;
	}

    private AdRequest CreateAdRequest() {
		return new AdRequest.Builder()
			.AddTestDevice("5E88667E634FF74B042F4815C25927A8")
			.AddKeyword("game")
			.SetGender(Gender.Male)
			.SetBirthday(new DateTime(1985, 1, 1))
			.TagForChildDirectedTreatment(false)
			.AddExtra("color_bg", "9B30FF")
			.Build();
	}

	public void RequestNewBannerAd() {
		bannerAd.LoadAd(CreateAdRequest());
	}

	public void RequestNewInterstitialAd() {
		interstitial.LoadAd(CreateAdRequest());
	}

	public void ShowBanner() {
		bannerAd.Show();
	}

	public void HideBanner() {
		bannerAd.Hide();
	}

	public void ShowInterstitital() {
		showInterstitialCounter--;

		if (showInterstitialCounter <= 0 && interstitial.IsLoaded()) {
			interstitial.Show();
		}
	}

	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args){
		RequestNewInterstitialAd();
	}
	
	void HandleInterstitial(object sender, EventArgs e) {
		showInterstitialCounter = UnityEngine.Random.Range(5, 7);
		RequestNewInterstitialAd();
	}
}