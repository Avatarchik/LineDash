using UnityEngine;
using System.Collections;

// MainClass 
public class ObjectZone : MonoBehaviour , IObstacleSwitch {
	public virtual void Wakeup(){
		Debug.Log ("wakeup");
	}
}
