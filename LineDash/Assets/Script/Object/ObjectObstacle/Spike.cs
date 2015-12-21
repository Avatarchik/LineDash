using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D  who){
		if (who.tag == "Player") {
			//StartCoroutine ("WarpObject",who);
			Messenger.Broadcast(PlayerEvent.HIT_SPIKE);
		}

	}
}
