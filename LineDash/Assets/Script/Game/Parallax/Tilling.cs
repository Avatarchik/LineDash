using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Tilling : MonoBehaviour {
	public int offsetX = 2;

	public bool hasARightBuddy = false;
	public bool hasALeftBuddy = false;
	public bool reverseScale = false;

	private float spriteWidth = 0f;
	private Camera cam;
	private Transform myTransform;
	public bool isMain = false;
	public bool sky = false;
	SpriteRenderer sRenderer;
	void Awake(){
		
		cam = Camera.main;
		myTransform = transform;
	}
	void Start(){
		Messenger.AddListener (ThemeEvent.CHANGE_THEME, OnChangeTheme);
		sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;
		if (sky) {
			sRenderer.DOColor (GameManager.instance.colorTheme.HillColor,0);
		}
	}
	void Update(){
		if (hasALeftBuddy == false || hasARightBuddy == false) {
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false) {
				MakeNewBuddy (1);
				hasARightBuddy = true;
			}else if(cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false){
				MakeNewBuddy (-1);
				hasALeftBuddy = true;
			}
		}
		if (cam.transform.position.x - myTransform.position.x  > spriteWidth) {
			if (!isMain) {
				Destroy (myTransform.gameObject);
			}
		}
	}

	void MakeNewBuddy(int rightOrLeft){
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft,myTransform.position.y,myTransform.position.z);
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;
		newBuddy.GetComponent<Tilling> ().isMain = false;
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x * -1,newBuddy.localScale.y,newBuddy.localScale.z);
		}
		newBuddy.SetParent (myTransform.parent);
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tilling> ().hasALeftBuddy = true;
		} else {
			newBuddy.GetComponent<Tilling> ().hasARightBuddy = true;
		}
	}
	void OnChangeTheme(){
		sRenderer.DOColor (GameManager.instance.colorTheme.HillColor,1);
	}

}
