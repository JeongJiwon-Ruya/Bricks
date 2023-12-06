using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour {
  public AdmobManager admobManager;
  public Button startButton;

  private void Start() {
    startButton.onClick.AddListener(StartButtonClick);
    if(StaticGameData.initialPlay) admobManager.LoadInterstitialAd();
  }

  private void StartButtonClick() {
    StaticGameData.initialPlay = true;
    SceneManager.LoadScene("GameScene");
  }
}
