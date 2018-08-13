using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour {

	public abstract void MoveLeft();
	public abstract void MoveRight();
	public abstract void Jump();
}
