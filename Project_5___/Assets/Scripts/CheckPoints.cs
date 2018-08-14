using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	public Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) // if the player enter the checkpoint this sets the start position of the player pawn to this checkpoint
	{
		if (other.gameObject.tag == "player")
		{
			other.gameObject.GetComponent<PawnPlayer>().startPosition = tf.position;
		}
	}
}
