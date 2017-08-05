using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text secondsSurvivedUI;
	bool isGameOver;

	void Start()
	{
		//subscribe the OnGameOver method to the OnPlayerDeath event
		FindObjectOfType<PlayerMovement>().OnPlayerDeath += OnGameOver;
	}

	void Update () {
		//if game is over and we press space reload the scene
		if (isGameOver)	
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(0);
			}
		
	}


	//when the game is over -> enable the gameoverscreen, show the seconds survived on the UI
	void OnGameOver()
	{
		isGameOver = true;
		gameOverScreen.SetActive(true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
	}
}
