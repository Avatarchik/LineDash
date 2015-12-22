using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

		static GameManager _instance;
		public bool isDelete = false,gameEnd=false;
		public int countDraw = 0;
		public int limitDraw = 5;
		
		[SerializeField]bool gameStart = false;
		[SerializeField]bool gamePause = true;
		[SerializeField]public ColorTheme colorTheme = new ColorTheme();
		public static GameManager instance{
				get{
						if (_instance == null) {
								_instance = new GameObject ("GameManager").AddComponent<GameManager> ();
								DontDestroyOnLoad (GameManager.instance);
								
						}
						return _instance;
				}
		}
	public void Init(){
		//Messenger.Broadcast (GameEvent.GAME_MANAGER_INIT);
	}
	private int _score = 0;
	public int score{
		get{
			return _score;
		}
		set{
			_score = value;
			UIManager.instance.SendMessage ("SetScore",score);
			if (score % 15 == 0 && score != 0) {
				ChangeColor ();
			}
		}
	}
	private int _gem = 0;
	public int gem{
		get{
			return _gem;
		}
		set{
			_gem = value;
			Debug.Log ("GEM : " + _gem);
			UIManager.instance.SendMessage ("SetGem", _gem);
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
		//wallColor = Random.Range (0, 10) > 5 ? Color.red : Color.yellow;
		colorTheme.GenerateWallColor();
		EventManager.instance.ChangeColor ();
	}

	void OnGameOver(){
		colorTheme.WallColor = colorTheme.BaseWallColor;
		GameStop ();
	}
}
