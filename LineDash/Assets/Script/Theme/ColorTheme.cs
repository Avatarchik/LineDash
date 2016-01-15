using UnityEngine;
using System.Collections;

public enum ThemeChoice{
	Tearing_Away = 0,Darth_Veder = 1
}

public class ColorTheme{

	// Wall
	// สีกำแพง
	void Awake(){
		//GetTheme (ThemeChoice.Darth_Veder);
	}


	public string nameTheme = "";
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

	private Color hillColor;
	public Color HillColor{ get{return hillColor;}set{hillColor = value;}}

	private Color skyColor;
	public Color SkyColor{ get{return skyColor;}set{skyColor = value;}}

	private Color[] wallTheme;
	public void GenerateWallColor(){
		wallColor = wallTheme[Random.Range (0, wallTheme.Length)];
	}
	public void GetTheme(ThemeChoice theme){
		switch(theme){
		case ThemeChoice.Tearing_Away :
			SetTheme(new TearingAwayTheme());
			break;
		case ThemeChoice.Darth_Veder:
			SetTheme(new DarthVederTheme());
			break;
		}
	}
	public void GetTheme(int index){
		switch(index){
		case 0 :
			SetTheme(new TearingAwayTheme());
			break;
		case 1 :
			SetTheme(new DarthVederTheme());
			break;
		}

	}
	private void SetTheme(Theme theme){
		hillColor = theme.Hill;
		skyColor = theme.Sky;
		wallTheme = theme.WallTheme;
		nameTheme = theme.NameTheme;
		GenerateWallColor ();
	//	EventManager.instance.ChangeTheme ();
		Messenger.Broadcast (ThemeEvent.CHANGE_THEME);

	}
}
