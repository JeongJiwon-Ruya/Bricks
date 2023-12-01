using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BezierTest : MonoBehaviour {
	public GameObject torpedo;
	public List<Transform> transformList;
	private List<Vector3> vectorsList;
	public float speed; //speed를 조절하면 진행속도가 빨라짐.
	
	private void Start() {
		vectorsList = new List<Vector3>();
		foreach (var objTransform in transformList) {
			vectorsList.Add(objTransform.position);
		}
		StartCoroutine(Func());
	}

	private static Vector3 Bezier(List<Vector3> points, float value) {
		List<Vector3> step1 = points.ToList();
		int pastTemp = 0;
		for(int i = 1; i < points.Count; i++) {
			var temp = step1.Count;
			for(int j = pastTemp; j < temp-1; j++) {
				step1.Add(Vector3.Lerp(step1[j], step1[j+1], value));
			}
			pastTemp = temp;
		}
		return step1.Last();
	}
	
	IEnumerator Func() {
		var value = 0.0f; //0 : 시작점   1 : 도착지점
		while(value < 1.0f) {
			torpedo.transform.position = Bezier(vectorsList, value);
			value += Time.deltaTime*speed;
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
