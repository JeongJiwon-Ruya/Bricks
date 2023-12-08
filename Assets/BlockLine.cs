using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;

public class BlockLine : MonoBehaviour {
  public int[] blockColorSet = {0, 1, 2, 3, 4};
	public List<Block> blocks;

  private void Start() {
    this.UpdateAsObservable()
    .Where(_ => GeneralBlockSetting.gameState == GameState.Play)
    .Subscribe(_ => transform.Translate(0, GeneralBlockSetting.blockSpeed, 0));
  }

  public void Initialize() {
		blockColorSet = blockColorSet.OrderBy(_ => Guid.NewGuid()).ToArray();
		for (var index = 0; index < blocks.Count; index++) {
			blocks[index].SetColor(blockColorSet[index]);
		}
	}

  public async void DestroyAnimation() {
    var blocks = GetComponentsInChildren<Block>();
    var completeCount = 0;
    foreach (var block in blocks) {
      block.boxCollider2D.enabled = false;
      block.blockImage.DOFade(0, 0.9f).OnComplete((() => completeCount++));
    }
    await Awaiters.Until((() => completeCount >= 4));
    Destroy(gameObject);
  }
}
