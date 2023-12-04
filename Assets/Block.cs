using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Block : MonoBehaviour {
	[SerializeField]private int serialCode;
	public BlockColor blockColor;

	public void SetColor(int index) {
		blockColor = (BlockColor)index;
		GetComponent<Image>().color = Palette.BlockColors[index];
	}


	public int GetSerialCode() {
		return serialCode;
	}
}
