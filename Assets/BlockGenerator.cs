using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {
  public GameManager gameManager;
	public Transform boxPanel;
	
	public BlockLine blockPrefab;

	public List<BlockLine> blockLines;

  private float timeSinceLastSpawn;

  void Awake() {
		blockLines = new List<BlockLine>();
    for (int i = 0; i < 5; i++) {
      MakeOneBlockLine();
    }
  }

  private void Update() {
    if (GeneralBlockSetting.gameState == GameState.Over) return;
    
    if (GeneralBlockSetting.RespawnTime < timeSinceLastSpawn) {
      timeSinceLastSpawn = 0f;
      MakeOneBlockLine();
    } else timeSinceLastSpawn += Time.deltaTime;
  }

  private void MakeOneBlockLine() {
    var newLine = Instantiate(blockPrefab, boxPanel);
    var setYPosition = (blockLines.Count == 0 ? GeneralBlockSetting.BlockSize*4 : blockLines.Last().transform.localPosition.y) - GeneralBlockSetting.BlockSize;
    newLine.transform.localPosition = new Vector3(0, setYPosition, 0);
    newLine.Initialize();
	  blockLines.Add(newLine);
  }

  public void DestroyTopBlockLine() {
    gameManager.AddScore();
    var topLine = blockLines[0];
    topLine.DestroyAnimation();
    blockLines.Remove(topLine);
  }

  public void GameOverAnimation() {
    
  }
}
