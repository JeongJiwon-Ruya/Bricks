using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class PlayableBlockManager : MonoBehaviour {
	[SerializeField] private int currentBlockIndex;
	
	public GameManager gameManager;

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
		
		currentBlockColor = (BlockColor)Random.Range(0, 4);
		Debug.Log(currentBlockColor);
	}

	public void GravityOn() {
		rising = false;
		rigidBody.bodyType = RigidbodyType2D.Dynamic;
	}

	private void OnTriggerEnter2D(Collider2D col) {
		Debug.Log(col.tag);
		if (col.CompareTag($"Block")) ReturnToRising(col.transform.localPosition);
	}

	private void ReturnToRising(Vector3 resetPosition) {
		Debug.Log("return");
		rigidBody.bodyType = RigidbodyType2D.Static;
		rising = true;
		transform.localPosition = new Vector3(resetPosition.x, resetPosition.y+GeneralBlockSetting.BlockSize, resetPosition.z);
	}
}
