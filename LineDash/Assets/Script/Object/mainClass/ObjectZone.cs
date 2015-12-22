using UnityEngine;
using System.Collections;

// MainClass 
public class ObjectZone : MonoBehaviour , IObstacleSwitch,IColorTheme {
	public virtual void Wakeup(){
		Debug.Log ("wakeup");
	}
	public virtual void GetBaseColor(){
		Debug.Log ("GetBaseColor");
	}
	public virtual void GetTheme(){
		Debug.Log ("GetTheme");
	}
	public virtual void GetBaseTheme(){
		Debug.Log("GetBaseTheme");
	}
}
