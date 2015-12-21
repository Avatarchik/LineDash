using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

		static GameManager _instance;
		public bool isDelete = false,gameEnd=false;
		public int countDraw = 0;
		public int limitDraw = 5;
		public Color wallColor;
		[SerializeField]bool gameStart = false;
		[SerializeField]bool gamePause = true;
		public static GameManager instance{
				get{
						if (_instance == null) {
								_instance = new GameObject ("GameManager").AddComponent<GameManager> ();
								DontDestroyOnLoad (GameManager.instance);
						}
						return _instance;
				}
		}
	private int _score = 0;
	public int score{
		get{
			return _score;
		}
		set{
			_score = value;
			Debug.Log ("score is " + _score);
			UIManager.instance.SendMessage ("SetScore",score);
			if (score % 15 == 0) {
				ChangeColor ();
			}
		}
	}
	public bool IsGameStart(){
		return gameStart;
	}
	public bool IsGamePause (){
		return gamePause;
	}
	public void GameStart(){
		score = 0;
		gameStart = true;
		gamePause = false;
		Messenger.Broadcast (GameEvent.GAME_START, gameStart);
	}
	public void GameStop(){
		gameStart = false;

		Messenger.Broadcast (GameEvent.GAME_START, gameStart);
	}
	public void GamePause(){
		gamePause = !gamePause;

		Messenger.Broadcast (GameEvent.GAME_PAUSE, gamePause);
		//SendMessageUpwards ("OnGamePause", gamePause);
		//SendMessageUpwards
		//BroadcastMessage
		//SendMessage
	}
	public void ChangeColor(){
		wallColor = Random.Range (0, 10) > 5 ? Color.red : Color.yellow;
		Messenger.Broadcast (GameEvent.CHANGE_COLOR);
	}

	void OnGameOver(){
		GameStop ();
	}
}
