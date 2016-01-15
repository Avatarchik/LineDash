using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	//Y10 -10 , X -2 2
	void OnEnable(){
		this.gameObject.transform.localPosition = new Vector3(Random.Range(-2,2)+(Random.Range(0,99)*0.01f),
			Random.Range(-5,5)+(Random.Range(0,99)*0.01f),0);
		GetComponent<SpriteRenderer> ().color = new Color32 ((byte)Random.Range (100, 255), (byte)Random.Range (100, 255), (byte)Random.Range (100, 255),255);
	}
}
