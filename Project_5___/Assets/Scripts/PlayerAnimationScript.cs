using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{

	public Animator an;
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	private ControllerPlayer PcS;

	// Use this for initialization
	void Start()
	{
		an = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		PcS = GetComponent<ControllerPlayer>();
	}

	// Update is called once per frame
	void Update()
	{
		//if playerpawn is moving up or down play jump animation
		if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
		{
			an.Play("Jump");
		}
		else if (PcS.isMove == true) // if player is moving play walk animation unless the player is jumping
		{
			if (PcS.isJump == false)
			{
				an.Play("Player_WalkAnimation");
			}
		}
		else if (rb.velocity.x == 0)// if player is not moving play idle animation
		{
			an.Play("Idle_Animation");
		}
	}
}
