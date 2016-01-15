using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SaveManager : MonoBehaviour {
	static SaveManager _instance;
	public int bestScore;
	public int coin;
	string character_id = "c_0";
	Dictionary<string, bool> character;
	Dictionary<string, bool> saveCharacter = new Dictionary<string, bool> (){
		{"c_0", true}, {"c_1", true}, {"c_2", false},{"c_3", false},{"c_4", true},{"c_5", false},{"c_6", false}
	};

	public static SaveManager Instance{
			get{
				if (_instance == null) {
					_instance = new GameObject ("SaveManager").AddComponent<SaveManager> ();
					DontDestroyOnLoad (SaveManager._instance);
				}
				return _instance;
			}
	}
	public void LoadAllCharacter(){
		character = PlayerPrefsUtility.LoadDict<string, bool> ("CharacterSaveKey");
		if (character.Count <= 0) {
			PlayerPrefsUtility.SaveDict ("CharacterSaveKey", saveCharacter);
		}
		splitCharacter ();
	}
	public void SaveAllCharacter(){
		PlayerPrefsUtility.SaveDict ("CharacterSaveKey", character);
	}

	public string GetCurrentCharacter(){
		return character_id;
	}
	public void SaveCurrentCharacter(string id){
		PlayerPrefsUtility.Save ("CharacterKey",id);
	}
	public void LoadCurrentCharacter(string id){
	//	character_id = PlayerPrefsUtility.Load ("CharacterKey",string);
		string aaa = PlayerPrefsUtility.Load("aaa",default(string));
		if (string.IsNullOrEmpty (character_id)) {
			character_id = "c_0";
			SaveCurrentCharacter (character_id);
		}
	}

	public void splitCharacter(){
		List<string> split = new List<string> ();
		foreach( KeyValuePair<string, bool> kvp in character )
		{
			if (kvp.Value == false) {
				split.Add (kvp.Key);
			}
		}
		int rand = Random.Range (0, split.Count);
		character [split [rand]] = true;
		SaveAllCharacter ();
	}

}
