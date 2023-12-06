using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public enum GameState {Play, Over}

public class GameManager : MonoBehaviour {
  
  
  public PlayableBlockManager playableBlock;

  public BlockGenerator blockGenerator;

  public TextMeshProUGUI scoreBoard;

  public GameObject gameOverPopup;
  
  public Transform endLine;
  private float endLinePosY;
  
  public int score;
  
  private void Start() {
    Application.targetFrameRate = 60;
    GeneralBlockSetting.gameState = GameState.Play;
    endLinePosY = endLine.position.y;
  }

  private void Update() {
    if (GeneralBlockSetting.gameState == GameState.Over) return;
    if (endLinePosY < playableBlock.transform.position.y) GameOver();
  }

  public void AddScore() {
    score++;
    scoreBoard.text = score.ToString();
  }
  
	public void SetBlockPosition(int index) {
    if(blockGenerator.blockLines[0].blocks[index].blockColor == playableBlock.currentBlockColor) {
      blockGenerator.DestroyTopBlockLine();
	    playableBlock.GravityOn();
    }
	}

  public void GameOver() {
    gameOverPopup.SetActive(true);
    GeneralBlockSetting.gameState = GameState.Over;
    blockGenerator.GameOverAnimation();
  }
}
