using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.gameObject.transform.position = other.gameObject.GetComponent<PawnPlayer>().startPosition;
            --GameManager.instance.playerLives;
            GameManager.instance.pLives.text = ("Player Lives = " + GameManager.instance.playerLives);
        }
    }

}
