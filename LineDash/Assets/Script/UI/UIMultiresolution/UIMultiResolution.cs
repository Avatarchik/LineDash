using UnityEngine;
using System.Collections;

public class UIMultiResolution : MonoBehaviour {

	[SerializeField]GameObject[] uiObjects;
	// Use this for initialization
	void Start () {

		#if UNITY_IOS
		if((UnityEngine.iOS.Device.generation.ToString()).IndexOf("iPad") > -1){
			for(int i = 0 ; i <uiObjects.Length ; i++){
				uiObjects[i].transform.localScale = new Vector3(0.8f,0.8f,0.8f);
			}
		}
		#endif
	}

}
