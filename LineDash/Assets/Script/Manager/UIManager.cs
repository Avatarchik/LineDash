using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	
	//int fadeAlpha = 0;
	//float timeFade = 1.0f;
	Image imgFader;
	public static UIManager instance;
	[SerializeField]public GameObject UIGameOver,UIGameMenu;
	public Button b_draw, b_delete,b_pause;
	[SerializeField] Text score_txt;
	void Awake(){
		instance = this;
	}
	void Start(){
		b_pause.onClick.AddListener (PauseGame);
		Messenger.AddListener<bool>(GameEvent.GAME_PAUSE, OnGamePause);
	}

	void OnPlayerStart(){
		
	}

	void SetScore(int score){
		score_txt.text = score.ToString ();
	}
	void OnGameOver(){
		UIGameOver.SetActive (true);
	}
	void PauseGame(){
		GameManager.instance.GamePause ();
	}
	void OnGamePause(bool gamePause){
		Debug.Log ("UIMANAGER OnGamePause " + gamePause);
	}
}
