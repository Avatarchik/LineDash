using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
	[SerializeField]int id;
	[SerializeField]Button button;
	[SerializeField]bool isLock = false;
	// Use this for initialization
	void Start () {
		button.onClick.AddListener (OnClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
		if (isLock)
			return;
		Messenger.Broadcast (CharacterEvent.CHANGE_CHARACTER, id);
	}
}
