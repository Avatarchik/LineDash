using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Wall : ObjectZone {
	[SerializeField]GameObject wallUp = null,wallDown = null;
	[SerializeField]float distace;
	[SerializeField]float posY,posY2;
	int minDistance = -2;
	int maxDistance = 2;
	//ระยะทางต่ำสุด -3 มากสุด 3
	//ช่องว่าง 6
	// Use this for initialization
	void Start () {
		
	}
	public void Wakeup(){
		MoveTwoWall ();
		//PingPongWall();
	}
	void OnDisable(){
		Debug.Log ("Disable");
		Messenger.RemoveListener(GameEvent.CHANGE_COLOR, OnChangeColor);
		wallUp.transform.localPosition = new Vector2 (0, 10);
		wallDown.transform.localPosition = new Vector2 (0, -10);
		wallUp.transform.DOKill (false);
		wallDown.transform.DOKill (false);
		transform.DOKill (false);
		//Messenger.RemoveListener (GameEvent.CHANGE_COLOR, OnChangeColor);
	}
	// Wall เคลื่อนไหวแบบต่างๆ 
	void OnEnable(){
		Messenger.AddListener(GameEvent.CHANGE_COLOR, OnChangeColor);
		OnChangeColor ();
	}

	void OnChangeColor(){
		wallUp.GetComponent<SpriteRenderer> ().DOColor (GameManager.instance.wallColor, 1).SetAutoKill();
		wallDown.GetComponent<SpriteRenderer> ().DOColor (GameManager.instance.wallColor, 1).SetAutoKill();
	}
	void MoveOneWall(){
		// 7 - 11 กำลังดี
		posY = Random.Range (8, 11);
		if (Random.Range (0, 100) > 50) {
			posY *= -1;
		}
		transform.DOLocalMoveY ((float)posY, 0.5f);

	}
	void MoveTwoWall(){
		posY = Random.Range (-3, 3);
		posY2 = Random.Range (0, 99) * 0.01f;
		posY = posY + posY2;
		transform.DOLocalMoveY ((float)posY,1f,false);
		wallUp.transform.DOLocalMoveY (2.3f, 1, false);
		wallDown.transform.DOLocalMoveY (-2.3f, 1, false);
	}
	//pingpong wall
	void PingPongWall(){
		posY = Random.Range (-2, 2);
			if(Random.Range(0,100) > 50){
				posY = 3;
			}else{
				posY =-3;
			}
		transform.DOLocalMoveY ((float)posY,0.5f,false).OnComplete(PingPongMove);
		wallUp.transform.DOLocalMoveY (2.5f, 0.5f, false);
		wallDown.transform.DOLocalMoveY (-2.5f, 0.5f, false);

	}
	void PingPongMove(){
		transform.DOLocalMoveY (transform.localPosition.y*-1, 5).OnComplete (PingPongMove);
	}
	void OnLevelWasLoaded(int level) {
		Messenger.AddListener(GameEvent.CHANGE_COLOR, OnChangeColor);
	}
}
