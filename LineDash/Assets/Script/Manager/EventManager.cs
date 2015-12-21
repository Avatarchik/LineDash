using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
		public delegate void GameRestart(string msg);
		public static event GameRestart OnGameRestart;

		public delegate void GameOverEvent (bool isGameOver);
		public static event GameOverEvent OnGameOver;

		public delegate void DataUpdateEvent();
		public static event DataUpdateEvent OnDataUpdate;

		public delegate void SceneEvent(string mode);	
		public static event SceneEvent OnSceneDispatch;
		

		private static EventManager _instance;
		public static EventManager instance
		{
				get {
						if(_instance == null){
							_instance = new GameObject("EventManager").AddComponent<EventManager>();
						}
						DontDestroyOnLoad(_instance);
						return _instance;
				}
		}

		public void RestartGame(string msg){
				Debug.Log ("msg is " + msg);
				//OnGameRestart("restart "+msg);
				OnGameRestart (msg);
		}
		public void DataUpdate(){
				Debug.Log ("Broadcast DataUpdate");
				OnDataUpdate ();
		}
		public void GameOver(){
				OnGameOver (true);
		}
		public void Check(){
			//	Debug.Log ("initialize OK");
		}
	public void SceneDispatch(string mode){
		OnSceneDispatch (mode);
	}
}
