using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Draw : MonoBehaviour {

	// Use this for initialization
	//Camera mainCam;
	Vector3 pointStart,pointEnd;
	float angle,distance;
	bool isDraw = false;
	bool isStart = false;
	int bridgeLimit = 2;
	[SerializeField]List<GameObject> bridgeList = new List<GameObject>();
	GameObject bridge;
	void Start () {
		AssetManager.LoadResource ();
		//mainCam = Component.FindObjectOfType<Camera> ();
		//Messenger.AddListener(PlayerEvent.PLAYER_START , OnStart);

		pointStart = Vector3.zero;
		Messenger.AddListener<bool>(GameEvent.GAME_START ,OnGameStart);
		Messenger.AddListener<bool> (GameEvent.GAME_PAUSE, OnGamePause);
	}
	void OnEnable(){
		//Messenger.AddListener<bool>(GameEvent.GAME_START ,OnGameStart);
	}
	void OnDiable(){
		//Messenger.RemoveListener<bool>(GameEvent.GAME_START ,OnGameStart);
	}
	void OnDestroy(){
		Messenger.Cleanup ();
	}
	// Update is called once per frame
	//เปลี่ยนด่านแล้ว หา Camera ไม่เจอ
	void Update () {
		if (GameManager.instance.isDelete) {
			DeleteBridge ();
		} else {
			
			/*if (Input.GetMouseButtonDown (0)) {
				//if (GameManager.instance.countDraw >= GameManager.instance.limitDraw)
				//	return;
				pointStart = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				pointStart.z = 0;
			//	if (pointStart.x > 3.6f && pointStart.y < -2.1f) {
			//		return;
			//	}
				isDraw = true;
				bridge = Instantiate (AssetManager.bridge, pointStart, Quaternion.identity) as GameObject;
				GameManager.instance.IncreaseDraw ();
			}*/
			if (Input.GetMouseButtonDown (0)) {
				if(!GameManager.instance.IsGameStart() || GameManager.instance.IsGamePause()){
					return;
				}
			
				isDraw = true;
				bridge = ObjectPool.instance.GetBridge ();
				bridge.transform.position = pointStart;
				bridge.transform.localScale = Vector2.zero;
				//Instantiate (AssetManager.bridge, pointStart, Quaternion.identity) as GameObject;
				pointEnd = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				//Debug.Log (pointEnd);
				bridgeList.Add (bridge);
				CheckLimitBridge ();
				BridgeUpdate ();


				//isDraw = false;
				/*if (distance < 0.1) {
					Destroy (bridge);
					GameManager.instance.DecreaseDraw ();
					//isDraw = false;
				} else {
					if (bridge != null) {
						bridge.AddComponent<BoxCollider2D> ();
					}
				}*/

			}
		
		}
	}
	void BridgeUpdate(){
		if (!isDraw) {
			return;
		}

			pointEnd = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			distance = Vector2.Distance (pointStart, pointEnd);
			angle = Mathf.Atan2(pointEnd.y-pointStart.y, pointEnd.x-pointStart.x)*180 / Mathf.PI;
			//bridge.transform.localScale = new Vector3 (distance, 0.25f, 0);
			bridge.GetComponent<Bridge>().start = pointStart;
			bridge.GetComponent<Bridge>().end = pointEnd;
			bridge.transform.localRotation = Quaternion.Euler (0, 0, angle);
			bridge.transform.position = new Vector3 (bridge.transform.position.x,bridge.transform.position.y,0);
			bridge.transform.DOScaleY (0.25f, 0);
			bridge.transform.DOScaleX (distance, 0.5f);
			
			pointStart = pointEnd;


			
	}
	void DeleteBridge(){
		if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit2D rayHit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

				if (rayHit && rayHit.collider.gameObject.tag == "Bridge") {
					Destroy (rayHit.collider.gameObject);
					
				}
		}
	}
	void OnStart(){
		Debug.Log ("Game is start");
		isStart = true;
	}
	void OnGameStart(bool start){
		isStart = start;
	}
	void OnGamePause(bool gamePause){

	}
	void CheckLimitBridge(){
		if (bridgeList.Count > bridgeLimit) {
			// สักอย่าง
			bridgeList[0].GetComponent<Bridge>().Remove();
			bridgeList.RemoveAt (0);
		}
	}

}
