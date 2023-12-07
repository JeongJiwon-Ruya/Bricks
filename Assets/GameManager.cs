using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState {Play, Over}

public class GameManager : MonoBehaviour {
  /*
   * 남은 작업
   * 효과음 넣기 (버튼 클릭음 & 블록 없어질때 효과음)
   * best score 저장, 처리 ( 인게임에서 best score 넘으면 score창 연노랑(+애니메이션)으로 변경)
   */
  
  
  public PlayableBlockManager playableBlock;

  public BlockGenerator blockGenerator;

  public TextMeshProUGUI scoreBoard;
  public TextMeshProUGUI scoreBoardResult;
  
  public GameObject gameOverPopup;
  public Button replayButton;
  
  public Transform endLine;
  private float endLinePosY;

  public Text testtext;
  
  public int score;
  
  private void Start() {
    Application.targetFrameRate = 60;
    GeneralBlockSetting.gameState = GameState.Play;
    endLinePosY = endLine.position.y;
    replayButton.onClick.AddListener((() => SceneManager.LoadScene("IntroScene")));
  }

  private void Update() {
    if (GeneralBlockSetting.gameState == GameState.Over) return;
    if (endLinePosY < playableBlock.transform.position.y) GameOver();

  }
  public void AddScore() {
    score++;
    scoreBoard.text = score.ToString();
    //scoreBoardResult.text = score.ToString();
  }
  
	public void SetBlockPosition(int index) {
    if(blockGenerator.blockLines[0].blocks[index].blockColor == playableBlock.currentBlockColor) {
      blockGenerator.DestroyTopBlockLine();
	    playableBlock.GravityOn();
    }
	}

  public void GameOver() {
    gameOverPopup.SetActive(true);
    SetScoreAnimation();
    GeneralBlockSetting.gameState = GameState.Over;
    blockGenerator.GameOverAnimation();
  }

  public void SetScoreAnimation() {
    DOTween.To(() => 0, x => scoreBoardResult.text = x.ToString(), score, 2.0f).SetEase(Ease.OutCirc);
  }
}
