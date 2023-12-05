using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[SerializeField]private int currentBlockPosition;
	public PlayableBlockManager playableBlock;

  public BlockGenerator blockGenerator;

  public TextMeshProUGUI scoreBoard;
  public int score;
  
  private void Start() {
    Application.targetFrameRate = 60;
	}

  public void AddScore() {
    score++;
    scoreBoard.text = score.ToString();
  }
  
	public void SetBlockPosition(int index) {
    currentBlockPosition = index;
    if(blockGenerator.blockLines[0].blocks[index].blockColor == playableBlock.currentBlockColor) {
      blockGenerator.DestroyTopBlockLine();
	    playableBlock.GravityOn();
    }
	}
}
