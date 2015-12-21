using UnityEngine;
using System.Collections;
using DG.Tweening;
public class WallMove : ObjectZone {
	int posY = 40;
	public void Wakeup(){
		posY *= Random.Range (0, 100) > 50 ? -1 : 1;
		transform.DOLocalMoveY (posY, 30);
	}

}
