using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour {
  public AdmobManager admobManager;
  public Button startButton;

  public TextAnimator textAnimator;
  public GameObject bestScorePanel;

  private void Start() {
    startButton.onClick.AddListener(StartButtonClick);
    if(StaticGameData.initialPlay) admobManager.LoadInterstitialAd();
    textAnimator.PlayAnimation(bestScorePanel);
  }

  private void StartButtonClick() {
    StaticGameData.initialPlay = true;
    SceneManager.LoadScene("GameScene");
  }
}
