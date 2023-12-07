using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour {
  private Text targetText;
  public string inputString;
  public float duration;
  public Ease ease;
  
  private void Awake() {
    targetText = GetComponent<Text>();
    targetText.text = "";
  }

  public void PlayAnimation(GameObject panel) {
    targetText.DOText(inputString, duration).SetEase(ease).onComplete += () => panel.SetActive(true); // 나중에 action으로 구현
  }
}
