using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPlayer : Pawn {

	private Transform tf;
    private Rigidbody2D rb;
	public Vector3 startPosition; //the position this pawn starts from
    public GameObject bulletPrefab;// prefab of bullet object
    public Transform FireBallSpawnFront;// Spawn for fireball bullets
    public Transform FireBallSpawnBack;// Second place for fireballs to spanw out of 

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
		tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void MoveLeft() // moves the player left
	{
		tf.position += Vector3.left * GameManager.instance.playerMoveSpeed * Time.deltaTime;
	}

	public override void MoveRight() // moves player to the right
	{
		tf.position += Vector3.right * GameManager.instance.playerMoveSpeed * Time.deltaTime;
	}
	public override void Jump() // makes the player jump
	{
        rb.velocity = Vector3.up * GameManager.instance.jumpHeight;
	}
    public override void ShootForward() //Shoots a FireBall
    {
        GameObject bullet = Instantiate(bulletPrefab, FireBallSpawnFront.position, FireBallSpawnFront.rotation);
    }
    public override void ShootBackward() //Shoots a FireBall
    {
        GameObject bullet = Instantiate(bulletPrefab, FireBallSpawnBack.position, FireBallSpawnBack.rotation);
    }
}
