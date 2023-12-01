using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[SerializeField]private int currentBlockPosition;
	public PlayableBlockManager playableBlock;

	public List<Block> blocks;

	private void Start() {
		Application.targetFrameRate = 60;
	}

	public void SetBlockPosition(int index) {
    currentBlockPosition = index;
    if(blocks[index].blockColor == playableBlock.currentBlockColor) {
	    playableBlock.GravityOn();
	    Destroy(blocks[index].gameObject);
    }
	}
}
