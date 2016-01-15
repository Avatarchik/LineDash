using UnityEngine;
using System.Collections;
public class TearingAwayTheme : Theme {
	Color hill = Color.cyan;
	Color sky = Utils.HexToColor("#FFFCB1");
	Color[] wallTheme = new Color[]{Utils.HexToColor("#FEC653"),Utils.HexToColor("#C2FF9B"),Utils.HexToColor("#ACA2F4")};
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
