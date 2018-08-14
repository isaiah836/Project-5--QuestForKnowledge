using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGoblin : Controller {

    public SpriteRenderer sr;
    private Transform tf;//this gameObjects transform

    public bool isMove = true;
    public bool isRight = false;

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update() {
        if (isRight)
        {
            if (tf.position != pawn.WP1.position)
            {
                pawn.MoveRight();
                sr.flipX = false;
                if (tf.position == pawn.WP1.position)
                {
                    isRight = false;
                }
            }
        }
        else
        {
            if (tf.position != pawn.WP2.position)
            {
                pawn.MoveLeft();
                sr.flipX = true;
                if (tf.position == pawn.WP2.position)
                {
                    isRight = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.gameObject.transform.position = other.gameObject.GetComponent<PawnPlayer>().startPosition;
            --GameManager.instance.playerLives;
            GameManager.instance.pLives.text = ("Player Lives = " + GameManager.instance.playerLives);
        }
    }
}
