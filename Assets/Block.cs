using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour {
	[SerializeField]private int serialCode;
	public BlockColor blockColor;

	private void Start() {
		blockColor = (BlockColor)Random.Range(0, 5);
	}

	private void Update() {
	    transform.Translate(0,GeneralBlockSetting.BlockSpeed,0);
  }

	public int GetSerialCode() {
		return serialCode;
	}
}
