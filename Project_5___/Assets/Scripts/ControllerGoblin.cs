using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGoblin : Controller {

    public SpriteRenderer sr;
    private Transform tf;//this gameObjects transform

    public bool isRight = false;//controls whether or not the player is moving left or right

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();//grabs transform component
        sr = GetComponent<SpriteRenderer>();//grabs sprite renderer
	}

    // Update is called once per frame
    void Update() {
        if (isRight)//if is right is true then enemy goblin moves to the right
        {
            if (tf.position != pawn.WP1.position)
            {
                pawn.MoveRight();
                sr.flipX = false;
                if (tf.position == pawn.WP1.position) // if goblin reaches waypoint set is right to false
                {
                    isRight = false;
                }
            }
        }
        else//if is right is false then move goblin left to waypoint
        {
            if (tf.position != pawn.WP2.position)
            {
                pawn.MoveLeft();
                sr.flipX = true;
                if (tf.position == pawn.WP2.position)//if goblin reaches waypoint then set isright to true 
                {
                    isRight = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)//if goblin collides with player then reset player to last checkpoint, subtract live from player and update lives counter on canvas
    {
        if (other.gameObject.tag == "player")
        {
            other.gameObject.transform.position = other.gameObject.GetComponent<PawnPlayer>().startPosition;
            --GameManager.instance.playerLives;
            GameManager.instance.pLives.text = ("Player Lives = " + GameManager.instance.playerLives);
        }
    }
}
