using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject dead_particle;
	Vector2 vel;
	float timeIsStop;
	[SerializeField]Camera cam;
	Vector2 MaxDistance;
	Vector3 camMoveMent;
	int time = 0;
	int limit = 100;
	[SerializeField]bool isadd = false;
	void Awake(){
		

	}
	void OnDestroy(){
		Messenger.Cleanup ();
	}
	void Start () {
		cam = Camera.main;
		AddListenerMessage();
	}
	public void AddListenerMessage(){
		Messenger.AddListener <int>(CharacterEvent.CHANGE_CHARACTER,OnChangeCharacter);
		Messenger.AddListener<bool>(GameEvent.GAME_START ,OnGameStart);
		Messenger.AddListener<bool> (GameEvent.GAME_PAUSE, OnGamePause);
		Messenger.AddListener (PlayerEvent.PLAYER_HIT_GOAL, OnGoal);
		Messenger.AddListener (PlayerEvent.HIT_SPIKE, OnHitSpike);
		isadd = true;
		Debug.Log ("Listener Ready");
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
		camMoveMent = new Vector3 (this.gameObject.transform.position.x+3, 0, -100);
		cam.transform.position = Vector3.Lerp (cam.transform.position,camMoveMent,1);//new Vector3 (this.gameObject.transform.position.x+5, 0, -100);
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
		//dieObj.SetActive (true);
	}


	//hit

	void OnHitSpike(){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
		dead_particle.SetActive (true);
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
	void OnChangeCharacter(int index){
		GetComponent<SpriteRenderer> ().sprite = AssetManager.character_sprite.GetSprite ("c_" + index+".png");
	}
}
