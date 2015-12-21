using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectPool : MonoBehaviour {
	public static ObjectPool instance;
	public List<GameObject> blockPrototype;//ตัวแม่แบบ
	public List<GameObject> bridges;
	[SerializeField]List<GameObject> diamonds;
	[SerializeField]List<GameObject> obstacles;
	[SerializeField]List<GameObject> advanceObstacles;
	//[SerializeField]List<GameObject>

	// Use this for initialization

	//2wallmove 3 wallstar
	GameObject block;
	void Awake(){
		instance = this;
	}
	/*public static ObjectPool instance{
		get{
			if (_instance == null) {
				_instance = new ObjectPool ();
				DontDestroyOnLoad (_instance);
				_instance.objects = new List<GameObject> ();
			}
			return _instance;
		}
	}*/
	
	// Update is called once per frame
	void Update () {
	
	}
	public GameObject GetObstacle(){
		return GetObjectByList (obstacles,0);
	}
	public GameObject GetDiamond(){
		return GetObjectByList (diamonds,1);
	}
	public GameObject GetAdvanceObstacle(){
		int rand = Random.Range (0, advanceObstacles.Count);
		GameObject go = advanceObstacles [rand];
	
		if (!go.activeSelf) {
				go.SetActive (true);
				return go;
			}
		return CreateObjectByList (advanceObstacles,rand+2);
		//return GetObjectByList (advanceObstacles, 2+rand);
	}
	public void TestObject(){
		//Debug.Log ("TestObject");
		//GameObject go = Instantiate (blockPrototype [1]) as GameObject;
		//Debug.Log(go);
	}
	int bridgeIndex = 0;
	public GameObject GetBridge (){
		if (bridgeIndex >= 3) {
			bridgeIndex = 0;
		}
		return bridges [bridgeIndex++];
	}
	private GameObject GetObjectByList(List<GameObject> objList,int type){
		
		foreach (GameObject obj in objList) {
			if (!obj.activeSelf) {
				obj.SetActive (true);
				return obj;
			}
		}
		return CreateObjectByList (objList,type);
	}
	GameObject CreateObjectByList(List<GameObject> objList,int type){
		Debug.Log ("CreateObjectByList " + type);
		block = Instantiate (blockPrototype [type]) as GameObject;
		objList.Add (block);
		return block;
	}
	public void Recycle(GameObject obj){
		obj.SetActive(false);
	}
}
