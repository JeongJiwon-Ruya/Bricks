using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Block : MonoBehaviour {
	[SerializeField]private int serialCode;
	public BlockColor blockColor;
  public Image blockImage;
  public Collider2D boxCollider2D;

  public void SetColor(int index) {
		blockColor = (BlockColor)index;
		blockImage.color = Palette.BlockColors[index];
	}

  

	public int GetSerialCode() {
		return serialCode;
	}
}
