using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeAcquired : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "player")
		{
			GameManager.instance.LoadScenes(2);
		}
	}
}
