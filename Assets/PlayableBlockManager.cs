using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class PlayableBlockManager : MonoBehaviour {
	[SerializeField] private int currentBlockIndex;
  [SerializeField] private int changeColorCount;
  
	public GameManager gameManager;
  public BlockGenerator blockGenerator;
  
	private Rigidbody2D rigidBody;
	
	public BlockColor currentBlockColor;

	public bool rising = true;

	public void MovePosition(int index) {
		var movingDistance = Mathf.Abs(currentBlockIndex - index);
		currentBlockIndex = index;
		var destinationX = GeneralBlockSetting.BlockBasePositionX +GeneralBlockSetting.BlockSize * index;
		
		transform.DOLocalMoveX(destinationX, GeneralBlockSetting.PlayerBlockMoveDuration * movingDistance).SetEase(Ease.Linear)
		.OnComplete(() => gameManager.SetBlockPosition(index));
	}

	private void Update() {
		if(rising) transform.Translate(0,GeneralBlockSetting.BlockSpeed,0);
	}
	
	private void Start() {
		rigidBody = GetComponent<Rigidbody2D>();

    var firstBlockColor = blockGenerator.blockLines[0].blocks[0].blockColor;
    SetRandomColor(firstBlockColor);
  }

	public void GravityOn() {
		rising = false;
		rigidBody.bodyType = RigidbodyType2D.Dynamic;
	}

	private void OnTriggerEnter2D(Collider2D col) {
    if (col.CompareTag($"Block")) {
      if(col.GetComponent<Block>().blockColor == currentBlockColor) blockGenerator.DestroyTopBlockLine();
      else ReturnToRising(col.gameObject);
    }
	}

	private void ReturnToRising(GameObject colliderBlock) {
    var resetPosition = colliderBlock.transform.parent.localPosition;
    rigidBody.bodyType = RigidbodyType2D.Static;
		rising = true;
		transform.localPosition = new Vector3(transform.localPosition.x, resetPosition.y+GeneralBlockSetting.BlockSize - 5/*테스트 값*/, resetPosition.z);
    ChangeColorCount(colliderBlock.GetComponent<Block>().blockColor);
  }

  private void ChangeColorCount(BlockColor exceptionColor) {
    changeColorCount++;
    Debug.Log("count : " + changeColorCount);
    if (changeColorCount % 5 == 0) SetRandomColor(exceptionColor);
  }

  private void SetRandomColor(BlockColor exceptionColor) {
    var setArray = new List<int> { 0, 1, 2, 3, 4 };
    setArray.Remove((int)exceptionColor);
    setArray.Remove((int)currentBlockColor);
    
    currentBlockColor = (BlockColor)setArray.OrderBy(_ => Guid.NewGuid()).First();
    GetComponent<Image>().DOColor(Palette.BlockColors[(int)currentBlockColor], 0.5f).SetEase(Ease.InBounce);
    GeneralBlockSetting.BlockSpeed += 0.001f;
    GeneralBlockSetting.RespawnTime -= 0.001f;
  }
}
