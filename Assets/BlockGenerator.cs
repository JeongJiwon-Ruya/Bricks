using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockGenerator : MonoBehaviour {
	public Transform boxPanel;
	
	public BlockLine blockPrefab;

	public List<BlockLine> blockLines;

  private float timeSinceLastSpawn;
  private const float respawnTime = 1f;
  
  void Start() {
		blockLines = new List<BlockLine>();
    for (int i = 0; i < 5; i++) {
      MakeOneBlockLine();
    }
  }

  private void Update() {
    if (respawnTime < timeSinceLastSpawn) {
      timeSinceLastSpawn = 0f;
      MakeOneBlockLine();
    } else timeSinceLastSpawn += Time.deltaTime;
  }

  private void MakeOneBlockLine() {
    var newLine = Instantiate(blockPrefab, boxPanel);
    var setYPosition = (blockLines.Count == 0 ? GeneralBlockSetting.BlockSize : blockLines.Last().transform.localPosition.y) - GeneralBlockSetting.BlockSize;
    newLine.transform.localPosition = new Vector3(0, setYPosition, 0);
    newLine.Initialize();
	  blockLines.Add(newLine);
  }

  public void DestroyTopBlockLine() {
    Destroy(blockLines[0].gameObject);
    blockLines.RemoveAt(0);
  }
}
