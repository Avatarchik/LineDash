using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MainBG : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		Messenger.AddListener(ThemeEvent.CHANGE_THEME , OnChangeTheme);
	}
	void Start () {
		//Color color = Utils.HexToColor("FFA571");
		//Debug.Log (color);
	
		GetComponent<SpriteRenderer> ().color = GameManager.instance.colorTheme.SkyColor;
		//GetComponent<SpriteRenderer> ().DOColor (aaa,0);

	}

	/*void OnChangeTheme(){
		GetComponent<SpriteRenderer> ().DOColor (GameManager.instance.colorTheme.SkyColor, 1);
	}*/
	void OnLevelWasLoaded(int scene){
		Debug.Log ("Main BG Load");
		Messenger.AddListener(ThemeEvent.CHANGE_THEME , OnChangeTheme);
	}
	void OnEnable(){
		//Messenger.AddListener(ThemeEvent.CHANGE_THEME , OnChangeTheme);
	}
	void OnDisable(){
		//Messenger.RemoveListener(ThemeEvent.CHANGE_THEME , OnChangeTheme);
	}
	void OnChangeTheme(){
		GetComponent<SpriteRenderer> ().DOColor (GameManager.instance.colorTheme.SkyColor, 1);
	}
}
