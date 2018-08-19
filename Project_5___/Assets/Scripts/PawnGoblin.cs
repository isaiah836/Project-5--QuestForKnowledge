using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnGoblin : Pawn {

    private Transform tf;//variable for transform component
    public float goblinHealth;//variable containing gonlin health

    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();//grabs transoform component
	}
	
	// Update is called once per frame
	void Update () {
		if (goblinHealth < 1)//if goblin health reaches 0 then hide basically like it dying
        {
            gameObject.SetActive(false);
        }
	}
    public override void MoveLeft()//moves left 
    {
        transform.position = Vector3.MoveTowards(transform.position, WP2.position, GameManager.instance.goblinMoveSpeed * Time.deltaTime);
    }
    public override void MoveRight()//moves right
    {
        transform.position = Vector3.MoveTowards(transform.position, WP1.position, GameManager.instance.goblinMoveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)// if fireball enter trigger subtract 1 from goblin health
    {
        if(other.gameObject.tag == "fireball")
        {
            goblinHealth--;
        }
    }
}
