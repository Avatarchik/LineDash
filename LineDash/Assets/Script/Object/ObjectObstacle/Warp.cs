using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {
	public GameObject outWarp;
	void OnTriggerEnter2D(Collider2D  who){
		if (who.tag == "Player") {
			StartCoroutine ("WarpObject",who);
		}

	}
	IEnumerator WarpObject(Collider2D who){
		who.gameObject.transform.position = new Vector3 (100, 100, 100);
		who.gameObject.transform.position = outWarp.transform.position;
		who.gameObject.transform.rotation = outWarp.transform.rotation;
		who.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		yield return new WaitForSeconds (1);
		who.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		//who.gameObject.transform.position = outWarp.transform.position;
		//who.gameObject.transform.localPosition = who.gameObject.transform.right;
		//who.gameObject.transform.localRotation = outWarp.transform.localRotation;
		//who.gameObject.transform.rotation = outWarp.transform.rotation;
		//who.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		/*Vector3 dir = Quaternion.AngleAxis(Vector2.fin, Vector3.forward) * Vector3.right;
		rigidbody2D.AddForce(dir*force);*/
		GameObject GOD = GameObject.Find ("GOD");
		var angle = Vector2.Angle (who.transform.position, GOD.transform.position);
		Debug.Log ("ANGLR is !!!!!!!!! " + angle);
		float speed;
		if (who.gameObject.transform.rotation.z < -0.95) {
			speed = 0;
		} else if (who.gameObject.transform.rotation.z < -0.71 && who.gameObject.transform.rotation.z > -0.9) {
			speed = (400 - (Mathf.Abs (who.gameObject.transform.rotation.z * 300)));
			who.GetComponent<Rigidbody2D> ().AddForce (who.gameObject.transform.up * speed);
		}
		else {
			speed = (400 - (Mathf.Abs (who.gameObject.transform.rotation.z * 100)));
			who.GetComponent<Rigidbody2D> ().AddForce (who.gameObject.transform.up * speed);
		}

	}
}
