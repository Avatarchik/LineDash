using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Parallaxing: MonoBehaviour {

	public List<Transform> backgrounds;
	private float[] parallaxScale;
	public float smoothing = 1f;

	private Transform cam;
	private Vector3 previousCamPos;

	void Awake(){
		cam = Camera.main.transform;
	}
	void Start(){
		previousCamPos = cam.position;
		parallaxScale = new float[backgrounds.Count];

		for (int i = 0; i < backgrounds.Count; i++) {
			parallaxScale [i] = backgrounds [i].position.z *-1;
		}
	}
	void Update(){
		for (int i = 0; i < backgrounds.Count; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScale [i];
			float backgroundTargetPosX = backgrounds [i].position.x + parallax;
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX , backgrounds[i].position.y,backgrounds[i].position.z);
			backgrounds [i].position = Vector3.Lerp (backgrounds[i].position,backgroundTargetPos,smoothing *Time.deltaTime);
			if (cam.position.x - backgrounds [i].position.x > backgrounds [i].GetComponent<SpriteRenderer> ().sprite.bounds.size.x) {
				GameObject go = backgrounds [i].gameObject;
				backgrounds.RemoveAt (i);
				Destroy (go);
			}
		}
	}

}
