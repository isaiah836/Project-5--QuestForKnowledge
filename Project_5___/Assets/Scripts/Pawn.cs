using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour {

    public Transform WP1;//Waypoint for the ai
    public Transform WP2;//waypoint for the ai

    public virtual void MoveLeft()
    {

    }
	public virtual void MoveRight()
    {

    }
	public virtual void Jump()
    {

    }
    public virtual void ShootForward()
    {

    }
    public virtual void ShootBackward()
    {

    }
}
