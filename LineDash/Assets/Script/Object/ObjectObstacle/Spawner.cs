using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	GameObject block;
	void Start(){
		Messenger.AddListener (SpawnEvent.SPAWN_OBJECT, OnSpawnObject);
	}
	void OnSpawnObject(){
		// spawn here
		Debug.Log("Spawn now");
		if (GameManager.instance.score % 10 == 0) {
			block = ObjectPool.instance.GetAdvanceObstacle ();
		} else {
			block = ObjectPool.instance.GetObstacle ();
		}

		block.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		block.GetComponentInChildren<ItemSpawner> ().enabled = true;
	}
}
