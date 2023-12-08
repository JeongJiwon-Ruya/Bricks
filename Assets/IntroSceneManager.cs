using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour {
  public AdmobManager admobManager;
  public Button startButton;

  public TextAnimator textAnimator;
  public GameObject bestScorePanel;

  private void Start() {
    var textUI = bestScorePanel.GetComponent<TextMeshProUGUI>();
    textUI.text = $"Best Score\n{PlayerPrefs.GetInt("BESTSCORE").ToString()}";
    startButton.onClick.AddListener(StartButtonClick);
    if(StaticGameData.initialPlay) admobManager.LoadInterstitialAd();
    textAnimator.PlayAnimation(() => bestScorePanel.GetComponent<TextMeshProUGUI>().DOFade(1, 0.2f).SetEase(Ease.OutQuint));
  }

  private void StartButtonClick() {
    StaticGameData.initialPlay = true;
    SceneManager.LoadScene("GameScene");
  }
}
