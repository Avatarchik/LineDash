using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using Facebook;
using System.IO;
using System.Globalization;
public class Utils : MonoBehaviour {

	static Texture2D screenShot;
	public static void TakeScreenshot(){
		//Application.CaptureScreenshot ("screenshot.png");
		screenShot = new Texture2D(Screen.width, Screen.height,TextureFormat.ARGB32,true);
		Rect rect = new Rect( 0, 0, Screen.width, Screen.height );
		//yield new WaitForEndOfFrame();
		screenShot.ReadPixels (rect,0,0);
		screenShot.Apply();
	}
	public static void GetScreenshot(){
		byte[] bytes = screenShot.EncodeToPNG();
		//texture.LoadImage(bytes);
		/*Rect rec = new Rect(0, 0, tex.width, tex.height);
		Sprite sp= Sprite.Create (tex, rec, new Vector2 (0, 0), 1);

		Renderer go = new GameObject ("test").AddComponent<SpriteRenderer> ();
		go.GetComponent<SpriteRenderer> ().sprite = sp;*/

		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", bytes, "screenshot.png");
	//	FB.API("me/photos", Facebook.HttpMethod.POST, null, wwwForm);
	}
	public static T RandomEnum<T>(){
		System.Random rand = new System.Random ();
		var v = System.Enum.GetValues (typeof(T));
		return (T) v.GetValue (rand.Next(v.Length));
	}
		
	public static Color HexToColor(string aStr) {
		Color clr = new Color(0,0,0);
		if(aStr!=null && aStr.Length>0) {
			try {
				string str = aStr.Substring(1, aStr.Length - 1);
				clr.r = (float)System.Int32.Parse(str.Substring(0,2), 
					NumberStyles.AllowHexSpecifier) / 255.0f;
				clr.g = (float)System.Int32.Parse(str.Substring(2,2), 
					NumberStyles.AllowHexSpecifier) / 255.0f;
				clr.b = (float)System.Int32.Parse(str.Substring(4,2), 
					NumberStyles.AllowHexSpecifier) / 255.0f;
				if(str.Length==8) clr.a = System.Int32.Parse(str.Substring(6,2), 
					NumberStyles.AllowHexSpecifier) / 255.0f;
				else clr.a = 1.0f;
			} catch(System.Exception e) {
				Debug.Log("Could not convert "+aStr+" to Color. "+e);
				return new Color(0,0,0,0);
			}
		}
		return clr;

	}
}
