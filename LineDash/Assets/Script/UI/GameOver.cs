using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
	[SerializeField]Button b_replay;
	void Start(){
		b_replay.onClick.AddListener (OnReplay);
	}
	void OnReplay(){
		SceneManager.LoadScene ("Main");
	}
}
