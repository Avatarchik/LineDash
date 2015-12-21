using UnityEngine;
using System.Collections;

public class ActiveObject : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Respawn") {
			//other.gameObject.GetComponent<>
			//Debug.Log(gameObject.GetComponents(typeof(ObjectZone)));
			//IObstacleSwitch comps = other.gameObject.GetComponent (typeof(IObstacleSwitch)) as IObstacleSwitch;
			other.BroadcastMessage ("Wakeup"); // ใช้แบบนี้ก็ได้แฮะ

		} 
	}
}
