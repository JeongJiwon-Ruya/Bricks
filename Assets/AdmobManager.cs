using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AdmobManager : MonoBehaviour {
  
  
	public string adUnitID = "ca-app-pub-9865709739723149/1055185504";
  
  private string _adUnitId;

	private InterstitialAd interstitialAd;
	
	void Awake() {

		_adUnitId =  adUnitID;
		
		
	    MobileAds.Initialize((InitializationStatus status) => 
		    Debug.Log("AdMobInitialized"));
    
	}

	private void Start() {
		ShowAd();
	}

	public void LoadInterstitialAd() {
		if (interstitialAd != null) {
			interstitialAd.Destroy();
			interstitialAd = null;
		}

		Debug.Log("Loading the interstitial ad.");

		var adRequest = new AdRequest();
		adRequest.Keywords.Add("unity-admob-sample");
		
		InterstitialAd.Load(_adUnitId, adRequest, (InterstitialAd ad, LoadAdError error) => {
			if (error != null || ad == null) {
				Debug.LogError($"interstitial ad failed to load an ad with error : {error}");
				return;
			}

			Debug.Log($"Interstitial ad loaded with response : {ad.GetResponseInfo()}");

			interstitialAd = ad;
			RegisterEventHandlers(interstitialAd);
		});
	}

	public async void ShowAd() {
			await Awaiters.Until(() => interstitialAd != null);
			await Awaiters.Until(() => interstitialAd.CanShowAd());
			interstitialAd.Show();
	}
	
	private void RegisterEventHandlers(InterstitialAd ad)
	{
		// Raised when the ad is estimated to have earned money.
		ad.OnAdPaid += (AdValue adValue) =>
		{
			Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
				adValue.Value,
				adValue.CurrencyCode));
		};
		// Raised when an impression is recorded for an ad.
		ad.OnAdImpressionRecorded += () =>
		{
			Debug.Log("Interstitial ad recorded an impression.");
		};
		// Raised when a click is recorded for an ad.
		ad.OnAdClicked += () =>
		{
			Debug.Log("Interstitial ad was clicked.");
		};
		// Raised when an ad opened full screen content.
		ad.OnAdFullScreenContentOpened += () =>
		{
			Debug.Log("Interstitial ad full screen content opened.");
		};
		// Raised when the ad closed full screen content.
		ad.OnAdFullScreenContentClosed += () =>
		{
			Debug.Log("Interstitial ad full screen content closed.");
			LoadInterstitialAd();
    };
		// Raised when the ad failed to open full screen content.
		ad.OnAdFullScreenContentFailed += (AdError error) =>
		{
			Debug.LogError("Interstitial ad failed to open full screen content " +
			               "with error : " + error);
		};
	}

}
