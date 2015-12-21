using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Bridge : MonoBehaviour {
	public Vector2 start, end;
	GameObject go;
	//	public Vector2 end
	/*void OnTriggerEnter2D(Collider2D  who){
		
		Debug.Log ("trigger");
	}
	void OnCollisionEnter2D(Collision2D who){
		if (who.gameObject.GetComponent<Rigidbody2D> ().isKinematic) {
			Debug.Log ("isKinematic");
		}
		if (who.gameObject.tag == "Trap" && !GameManager.instance.isGameStart) {
			Destroy (this.gameObject);
		}
	}
	void OnCollisionStay2D(Collision2D coll) {
		//Debug.Log ("stay2D");
	}
	void OnCollision2D(Collision2D who){
		Debug.Log ("1");
	}
	void OnTriggerStay2D(Collider2D who) {
		Debug.Log ("2");
	}*/

	public void Remove(){
	//	gameObject.transform.rotation = Quaternion;
		//gameObject.transform.DOScaleX (0, 1);
		//Debug.Log (gameObject.GetComponent<SpriteRenderer> ().sprite);
		go = Instantiate(this.gameObject);
		Vector3 euler = this.gameObject.transform.rotation.eulerAngles;
		go.transform.rotation = Quaternion.Euler (new Vector3 (euler.x, euler.y, euler.z+180));
		go.transform.localPosition = end;
		go.transform.DOScaleX (0, 0.5f).OnComplete(RemoveObject);
		//Destroy (this.gameObject);
		this.gameObject.transform.position = new Vector2(1000,1000);
		//GetComponent<BoxCollider2D> ().isTrigger = true;
		//ก๊อบมาใหม่
		//ให้ตัวปัจจุบันcollider เป็น trigger
		//ปรับ rotate ให้อยุ่ตรงกันข้าม
		// move มาจุด end

		//animate!!
	}
	void RemoveObject(){
		Destroy (go);
	}
}
