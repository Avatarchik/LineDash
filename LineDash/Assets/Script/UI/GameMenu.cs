using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMenu : MonoBehaviour {
	[SerializeField]Button b_play;
	void Start(){
		b_play.onClick.AddListener (OnPlayGame);
	}
	void OnPlayGame(){
		// play
		this.gameObject.SetActive(false);
		GameManager.instance.GameStart ();
	}
}
