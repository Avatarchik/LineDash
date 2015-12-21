using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject particleObj,dead_particle;
	Vector2 vel;
	float timeIsStop;
	[SerializeField]Camera cam;
	Vector2 MaxDistance;
	int time = 0;
	int limit = 100;
	void Awake(){
		
	}
	void OnDestroy(){
		Messenger.Cleanup ();
	}
	void Start () {
		
		//GetComponent<Rigidbody2D> ().AddTorque (-100);
		Messenger.AddListener<bool>(GameEvent.GAME_START ,OnGameStart);
		Messenger.AddListener<bool> (GameEvent.GAME_PAUSE, OnGamePause);
		Messenger.AddListener (PlayerEvent.PLAYER_HIT_GOAL, OnGoal);
		Messenger.AddListener (PlayerEvent.HIT_SPIKE, OnHitSpike);
	}
	void OnEnable(){
		
		Debug.Log ("Player OnEnable");
	}
	void OnDiable(){
		/*Messenger.RemoveListener<bool>(GameEvent.GAME_START ,OnGameStart);
		Messenger.RemoveListener (PlayerEvent.PLAYER_HIT_GOAL, OnGoal);
		Messenger.RemoveListener (PlayerEvent.HIT_SPIKE, OnHitSpike);*/

		Debug.Log ("Player Disable");
	}
	void OnGameStart(bool gameStart){
		Debug.Log ("OnStart");
		GetComponent<Rigidbody2D> ().isKinematic = !gameStart;

	}
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.IsGamePause() || !GameManager.instance.IsGameStart())
			return;
		cam.transform.position = new Vector3 (this.gameObject.transform.position.x+5, 0, -100);
		//particleObj.transform.position = this.gameObject.transform.position;
		//Debug.Log (Vector2.Distance (this.gameObject.transform.position, MaxDistance));
		if (Vector2.Distance (this.gameObject.transform.position, MaxDistance) > 0.06) {
			MaxDistance = this.gameObject.transform.position;
			time = 0;
		} else {
			time++;
			if (time > limit) {
				OnHitSpike ();
			}
		}
	}
	void OnGoal(){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
		GameManager.instance.gameEnd = true;
		particleObj.SetActive (true);
	}


	//hit

	void OnHitSpike(){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
		//dead_particle.SetActive (true);
		StartCoroutine ("WaitToReplay");

	}
	IEnumerator WaitToReplay(){
		yield return new WaitForSeconds (0.1f);
		Debug.Log ("TogAmeOver");

		UIManager.instance.SendMessage ("OnGameOver");
		GameManager.instance.SendMessage ("OnGameOver");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall")
			OnHitSpike ();


	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "PointCencer") {
			//Debug.Log ("Get Point");
			GameManager.instance.score ++;
		} 
	}
	void OnGamePause(bool gamePause){
		GetComponent<Rigidbody2D> ().isKinematic = gamePause;
		Debug.Log ("Playser OngAmePause " + gamePause);
	}
}
