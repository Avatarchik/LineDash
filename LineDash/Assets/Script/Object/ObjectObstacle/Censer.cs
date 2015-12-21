using UnityEngine;
using System.Collections;

public class Censer : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D  who){
		if (who.tag == "Player") {
			Debug.Log (who.tag);
		
		}

	}
}
