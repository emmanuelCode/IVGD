using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	//
	public GameObject[] numbers;

	// wasn't able to replace a game object with another there was no setter...
	//public GameObject PlayerOneScore, PlayerTwoScore;
	
	//so..UI text for not wasting time on looking
	public Text playerOneScoreText, playerTwoScoreText;

	private int playerOneScore, playerTwoScore;

	// Use this for initialization
	void Start ()
	{

	

		

	}
	
	// Update is called once per frame
	void Update () {
		restartGame();
		playerWon();
	}
	
	
	// I added this because it take time for unity to load scene when I press play
	void restartGame()
	{
		
		if( Input.GetKeyDown(KeyCode.R) )
		{
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}
	}

	
	
	public void AddScoreToPlayerOne(int point)
	{
		playerOneScore += point;

		playerOneScoreText.text = "" + playerOneScore;

	}

	public void AddScoreToPlayerTwo(int point)
	{
		playerTwoScore += point;

		playerTwoScoreText.text = "" + playerTwoScore;
		
		
	}

	void playerWon()
	{
		if (playerOneScore == 9)
		{
			print("1st player: YOU WON");
			GameObject ball = GameObject.Find("Ball");
			Destroy(ball);
			
			
		}

		if (playerTwoScore == 9)
		{
			print("2nd player: YOU WON");
			GameObject ball = GameObject.Find("Ball");
			Destroy(ball);

		}

	}



}
