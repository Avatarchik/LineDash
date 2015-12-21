using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log ("GET GEM");
			ObjectPool.instance.Recycle (this.gameObject);
		}
	} 
	void OnDisable(){
		ObjectPool.instance.Recycle (this.gameObject);
	}
}
