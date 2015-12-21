using UnityEngine;
using System.Collections;

public class ShadowFake : MonoBehaviour {

	//ใช้ eluerAngles
	public float rotate,flipShadow,a,b;
	public Vector2 shadowPos,changeShadow,mod,divine;
	float valueX = 360;
	float valueY = 180;
	public bool isBridge = false;
	Transform shadow;
	void Start(){
		if (isBridge)
			return;
	//	StartShadow ();
		//Debug.Log ("rotate "+rotate);
		//shadow.localPosition = new Vector3 (changeShadow.x, changeShadow.y,shadow.localPosition.z);

	}
	public void StartShadow(){
		shadow = GetComponentInChildren<Shadow> ().gameObject.transform;
		shadowPos = GetComponentInChildren<Shadow> ().gameObject.transform.localPosition;

		rotate = transform.rotation.eulerAngles.z;
		mod.x = rotate;
		mod.y = rotate;

		changeShadow.x = -(shadowPos.x/90)*mod.x;
		changeShadow.y = -(shadowPos.y / 180) * mod.y;
		flipShadow = (rotate < 20) ? 1 : -1;
		shadow.localPosition = new Vector3 (shadow.localPosition.x, -flipShadow*shadow.localPosition.y, shadow.localPosition.z);


	}
	/*void Update(){
		transform.Rotate(Vector3.forward * Time.deltaTime*10);

		flipShadow = (rotate < 20) ? 1 : -1;
		shadow.localPosition = new Vector3 (flipShadow*shadow.localPosition.x, shadow.localPosition.y, shadow.localPosition.z);

	}*/
}
