using UnityEngine;
using System.Collections;
//using Facebook;
using System.IO;
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
}
