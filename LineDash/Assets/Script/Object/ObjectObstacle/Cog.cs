using UnityEngine;
using System.Collections;

public class Cog : MonoBehaviour {
	public bool useMoter;
	void OnCollisionEnter2D(Collision2D who){
		if (who.gameObject.tag == "Player") {
			this.gameObject.GetComponent<HingeJoint2D> ().useMotor = true;
		}
	}
}
