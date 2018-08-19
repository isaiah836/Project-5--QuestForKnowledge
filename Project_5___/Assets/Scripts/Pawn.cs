using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour {

    public Transform WP1;//Waypoint for the ai
    public Transform WP2;//waypoint for the ai

    public virtual void MoveLeft()//function for moving left
    {

    }
	public virtual void MoveRight()//function for moving right
	{

    }
	public virtual void Jump()//function for moving left jump
	{

    }
    public virtual void ShootForward()//function for moving shoot forward
	{

    }
    public virtual void ShootBackward()//function for moving shoot backward
	{

    }
}
