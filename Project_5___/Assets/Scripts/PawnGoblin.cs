using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnGoblin : Pawn {

    private Transform tf;
    public float goblinHealth;

    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (goblinHealth < 1)
        {
            gameObject.SetActive(false);
        }
	}
    public override void MoveLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, WP2.position, GameManager.instance.goblinMoveSpeed * Time.deltaTime);
    }
    public override void MoveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, WP1.position, GameManager.instance.goblinMoveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "fireball")
        {
            goblinHealth--;
        }
    }
}
