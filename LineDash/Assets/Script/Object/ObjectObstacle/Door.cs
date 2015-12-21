using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	bool isEnabled = true;
	void Awake(){
		EventManager.OnSceneDispatch += EventManager_OnSceneDispatch;
	}

	void OnDestroy(){
		EventManager.OnSceneDispatch -= EventManager_OnSceneDispatch;
	}
	void Start(){
		Debug.Log ("Door is ready");
	}

	void OnTriggerEnter2D(Collider2D  who){
		if (!isEnabled)
			return;
		if (who.tag == "Player") {
			Debug.Log (who.tag);
			Messenger.Broadcast (PlayerEvent.PLAYER_HIT_GOAL);

		}

	}
	void EventManager_OnSceneDispatch (string mode)
	{
		if (mode == SceneEvent.REPLAY) {
			isEnabled = false;
		}
	}
}
