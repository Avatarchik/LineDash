using UnityEngine;
using System.Collections;

public abstract class Theme : IBaseTheme {
	public abstract string NameTheme{get;set;}
	public abstract Color Hill{get;set;}
	public abstract Color Sky{get;set;}
	public abstract Color[] WallTheme{ get; set;}
}
