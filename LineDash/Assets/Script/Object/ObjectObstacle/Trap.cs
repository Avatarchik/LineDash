using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	void Awake(){
		Messenger.AddListener (PlayerEvent.PLAYER_START, OnStart);
	}
	void OnStart(){
		this.gameObject.GetComponent<Rigidbody2D> ().fixedAngle = false;
	}
}
