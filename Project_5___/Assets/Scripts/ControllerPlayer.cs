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

	public SpriteRenderer sr;

	public bool isMove; // a bool to see if the player is moving
	public bool isJump; // a bool that will tell if player is jumping
    public bool isShoot; // bool for shooting
    public bool canShoot = true;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>(); //grabs audi source
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
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			isMove = false;
		}

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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShoot = false;
        }

        // if space is pressed player jumps and makes jump sound
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
	}

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
