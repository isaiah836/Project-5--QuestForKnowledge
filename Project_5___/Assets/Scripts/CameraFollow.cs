using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, -10000, 10000);
        float y = Mathf.Clamp(player.transform.position.y, -10000, 10000);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
