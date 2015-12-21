using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {
	int spawnRate = 75;
	GameObject go;
	void OnEnable(){
		if (Random.Range (0, 100) > spawnRate) {
			CreateDiamond ();
		}
	}
	void CreateDiamond(){
		go = ObjectPool.instance.GetDiamond ();
		if (go != null) {
			go.transform.SetParent (this.gameObject.transform);
			go.transform.localPosition = Vector2.zero;
		}
		//Debug.Log (ObjectPool.instance);
		//ObjectPool.instance.TestObject ();
	}
}
