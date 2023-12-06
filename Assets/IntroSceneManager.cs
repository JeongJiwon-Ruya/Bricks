using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour {
  public Button startButton;

  private void Start() {
    startButton.onClick.AddListener(StartButtonClick);
  }

  private void StartButtonClick() {
    SceneManager.LoadScene("GameScene");
  }
}
