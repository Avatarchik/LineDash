using UnityEngine;
using System.Collections;

public class ColorTheme {
	
	// Wall
	// สีกำแพง
	private Color wallColor = Color.white;
	public Color WallColor{
		get{return wallColor;}
		set{wallColor = value;}
	}
	// base ของสีกำแพง
	private Color baseWallColor = Color.white;
	public Color BaseWallColor{
		get{return baseWallColor;}
		set{baseWallColor = value;}
	}
	public void GenerateWallColor(){
		wallColor = Random.Range(0,10) > 5 ? Color.red : Color.yellow;
	}
}
