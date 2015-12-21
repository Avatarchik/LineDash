using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AssetManager : MonoBehaviour {
	public static GameObject bridge;
	public static void LoadAsset(){


	}
	public static void LoadResource(){
		bridge = Resources.Load<GameObject> ("Prefab/bridge") as GameObject;

	}
}
