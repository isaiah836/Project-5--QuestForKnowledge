using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;


	//this a chunk of code is player settings
	[Header("Player Settings")]
	public GameObject Player;
	public float playerLives;
	public float playerMoveSpeed;
	public float jumpHeight;
	public float numofJumps;

    [Header("FireBall Settings")]
    public float fireBallLife;
    public float fireBallSpeed;

    [Header("Goblin Settings")]
    public float goblinMoveSpeed;

    public Text pLives;



	// Use this for initialization
	void Awake () {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		instance = this;
        pLives.text = ("Player Lives = " + playerLives);
    }
	
	// Update is called once per frame
	void Update () {
		if (playerLives < 1)// if player dies 3 time it displays defeat screen
		{
			LoadScenes(3);
		}
	}

	public void LoadScenes(int scene) // function that loads the scene in the game
	{
		SceneManager.LoadScene(scene);
	}

	public void Quit() // function that quits the game
	{
		Application.Quit();
	}
}
