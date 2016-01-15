using UnityEngine;
using System.Collections;

public interface IBaseTheme {
	string NameTheme{ get; set;}
	Color Hill{ get; set;}
	Color Sky{ get; set;}
	Color[] WallTheme{ get; set;}
}
