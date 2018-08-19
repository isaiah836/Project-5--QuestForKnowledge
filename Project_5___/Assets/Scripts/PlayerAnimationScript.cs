using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{

	public Animator an;//variable for animator component
	public Rigidbody2D rb;//variable for rigidbody2D component
	private ControllerPlayer PcS;//variable for my player controller script

	// Use this for initialization
	void Start()
	{
		an = GetComponent<Animator>();//grabs animator component
		rb = GetComponent<Rigidbody2D>();//grabs rigidbody2d component
		PcS = GetComponent<ControllerPlayer>();//grabs my player controller script
	}

	// Update is called once per frame
	void Update()
	{
		//if playerpawn is moving up or down play jump animation
		if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
		{
			an.Play("PlayerJumpAnim");
		}
        else if (PcS.isShoot == true)//if the player is shooting play the shooting animation
        {
            an.Play("Player_Attack");
        }
        else if (PcS.isMove == true) // if player is moving play walk animation unless the player is jumping
		{
			if (PcS.isJump == false && PcS.isShoot == false)
			{
				an.Play("Player_Walk");
			}
		}
        
		else if (rb.velocity.x == 0)// if player is not moving play idle animation
		{
			an.Play("Player_idle");
		}
        
	}
}
