using UnityEngine;
using System.Collections;
public class CameraMultiResolution : MonoBehaviour {
	private float aspect;
	// Use this for initialization
	public float shake = 0;
	public float shakeAmount = 0.2f;
	public float decreaseFactor = 1f;
	public float defaultSize;

	public Vector3 defaultPosition;
	public Vector3 originalPos;
	public float TARGET_WIDTH,TARGET_HEIGHT,PIXELS_TO_UNITS;
	[SerializeField]
	float desiredRatio,currentRatio,differenceInSize;
	bool isLandscape;
	void Start () {
		desiredRatio = (float)TARGET_WIDTH / (float)TARGET_HEIGHT;
		currentRatio = (float)Screen.width/(float)Screen.height;
		isLandscape = (TARGET_WIDTH > TARGET_HEIGHT) ? true : false;

		if (isLandscape) {
			if (desiredRatio >= currentRatio) {
				SetWidthScreenSide ();
			} else {
				SetHeightScreenSide ();
			}
		} else {
			if (desiredRatio >= currentRatio) {
				SetHeightScreenSide ();
			} else {
				SetWidthScreenSide ();
			}
		}
				defaultSize = Camera.main.orthographicSize;
				defaultPosition = Camera.main.transform.position;
	}

	void SetWidthScreenSide(){
		Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS;
	}
	void SetHeightScreenSide(){
		Debug.Log (Camera.main);
		differenceInSize = desiredRatio / currentRatio;
		Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS * differenceInSize;
	}
	void OnEnable()
		{
				originalPos = transform.localPosition;
		}

	/*void Update () {
				if (shake > 5) {
						shake = 5;
				}
				if (shake > 0)
				{
						transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

						//shake -= Time.deltaTime * decreaseFactor;
						shake -= 1;
				}
				else
				{
						shake = 0f;
						transform.localPosition = originalPos;
				}
	}*/
}
