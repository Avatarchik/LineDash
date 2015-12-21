using UnityEngine;
using System.Collections;

public class ChangeTransform : MonoBehaviour {

	public float scale;
	void OnTriggerEnter2D(Collider2D  who){
		if (who.tag == "Player") {
			if (who.gameObject.transform.localScale.x == scale)
				return;
			who.gameObject.transform.localScale = new Vector3 (scale, scale, scale);
		}

	}
}
