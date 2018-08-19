using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : Controller {

    public LayerMask ground; // checks which layaer mask to check for 
    public GameObject groundCheck; //the ground check gameObject
    public float groundCheckRadius; //ground check radius 
    public bool isGrounded; // bool to see if player is grounded
    public AudioClip jumpSound; // sound when player jumps
    public AudioClip deathSound; // sound when player dies
    public AudioClip shootSound;//sound when player attacks
    public AudioSource audio; // grabs audio component
    public float shootDelay;

	public SpriteRenderer sr;//variable for sprite renderer

	public bool isMove; // a bool to see if the player is moving
	public bool isJump; // a bool that will tell if player is jumping
    public bool isShoot; // bool for shooting
    public bool canShoot = true;// bool used for controlling how often the player can shoot

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>(); //grabs audio source
		sr = GetComponent<SpriteRenderer>(); // grabs sprite renderer component
	}

	// Update is called once per frame
	void Update() {
		isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, ground); //this checks to see if the player is grounded 
		

		//this chunk of code moves the player
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			pawn.MoveLeft();
			isMove = true;
			sr.flipX = true;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			pawn.MoveRight();
			isMove = true;
			sr.flipX = false;
		}
        //this sets the is move bool to false when the player lets go of the any of the movement keys
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			isMove = false;
		}


        //if the player presses space then it shoots a fireball
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            if (canShoot)
            {
                audio.PlayOneShot(shootSound);
                canShoot = false;
                StartCoroutine(Shooting());
                if (sr.flipX == false)
                {
                    isShoot = true;
                    pawn.ShootForward();
                }
                if (sr.flipX == true)
                {
                    isShoot = true;
                    pawn.ShootBackward();
                }
            }
        } 
        // this sets is shoot to false when the player releases the space key
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShoot = false;
        }

        // if up arrow or w key is pressed player jumps and makes jump sound
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
			if (GameManager.instance.numofJumps < 1)
            {
                audio.PlayOneShot(jumpSound);
                ++GameManager.instance.numofJumps;
				isJump = true;
                pawn.Jump();
            }
            
		}
		// if player is grounded reset jumps to zero
        if (isGrounded)
        {
            GameManager.instance.numofJumps = 0;
			isJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.Quit();
        }
	}

	//makes the player wait a set time before being able to fire again
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
