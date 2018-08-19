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

	//Fireball setting
    [Header("FireBall Settings")]
    public float fireBallLife;
    public float fireBallSpeed;

	//goblin settings
    [Header("Goblin Settings")]
    public float goblinMoveSpeed;

	//variable for the text that will display the amount of lives left
    public Text pLives;



	// Use this for initialization
	void Awake () {
		//make this gamemanager the only gamemanager and make instance = this
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		instance = this;
        pLives.text = ("Player Lives = " + playerLives);// sets lives to player lives and display
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
