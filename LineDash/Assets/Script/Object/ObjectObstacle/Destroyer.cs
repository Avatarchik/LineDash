using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Respawn") {
			//Debug.Log("Respawn");
			ObjectPool.instance.Recycle (other.gameObject);
			Messenger.Broadcast (SpawnEvent.SPAWN_OBJECT);
		} else {
			Destroy (other.gameObject);
		}

	}

}
