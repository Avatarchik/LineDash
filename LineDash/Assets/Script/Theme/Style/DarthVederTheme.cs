using UnityEngine;
using System.Collections;

public class DarthVederTheme : Theme {

	Color hill = Utils.HexToColor("#ACC3F2");
	Color sky = Utils.HexToColor("#202126");
	Color[] wallTheme = new Color[]{Utils.HexToColor("#455473"),Utils.HexToColor("#F23030"),Utils.HexToColor("#E6E2AF")};
	string nameTheme = "Tearing Away";
	public override string NameTheme {
		get {
			return nameTheme;
		}
		set {
			nameTheme = value;
		}
	}
	public override Color Hill {
		get {
			return hill;
		}
		set {
			hill = value;
		}
	}
	public override Color Sky {
		get {
			return sky;
		}
		set {
			sky = value;
			Debug.Log (sky);
		}
	}
	public override Color[] WallTheme {
		get {
			return wallTheme;
		}
		set {
			wallTheme = value;
		}
	}
}
