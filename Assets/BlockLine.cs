using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockLine : MonoBehaviour {
	public int[] blockColorSet = {0, 1, 2, 3, 4};
	public List<Block> blocks;
  

  public void Initialize() {
		blockColorSet = blockColorSet.OrderBy(_ => Guid.NewGuid()).ToArray();
		for (var index = 0; index < blocks.Count; index++) {
			blocks[index].SetColor(blockColorSet[index]);
		}
	}

	private void Update() {
		transform.Translate(0,GeneralBlockSetting.BlockSpeed,0);
	}
}
