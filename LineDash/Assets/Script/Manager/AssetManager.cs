using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AssetManager : MonoBehaviour {
	public static GameObject bridge;
	public static SpriteCollection character_sprite;
	public static void LoadAsset(){
		character_sprite = new SpriteCollection("Sprite/Character");
	}
	public static void LoadResource(){
		//bridge = Resources.Load<GameObject> ("Prefab/bridge") as GameObject;

	}

}
