/**
 
Mandatory Features (8 points)
*TODO The player moves left to right and up to down. DONE
*TODO The player can shoot 2 different kinds of bullets. DONE (press T for Twin Bullet )
*TODO The player has a set amount of lives which they loose when they get hit by enemies or by enemy bullets. DONE but need improvement for now...
*TODO The number of player lives left are displayed as cubes on the bottom left of the screen. DONE (displayed as planes sprite)
*TODO There are 2 enemy varieties DONE(blue and dark enemies)
*TODO Enemies move in (simple) patterns and shoot bullets DONE
*TODO The game keeps track of a score that tallies how many enemies the player destroys and prints it to the console. DONE
*TODO The game ends when a timer reaches 0 or a number of enemies are killed or a score is reached DONE
 

Bonus Features (2 points) NO TIME unfortunalty :(
* Obstacles scroll down for the player to avoid Getting there...(THE CODE IS THERE BUT COMMENT IT SINCE I CAN'T SEEM TO WORK IT RIGHT)
* Bullets from the player can collide with bullets from the enemies, destroying them
* Upgrades can appear in the level where an enemy dies and change certain aspects of the player (or their bullets) to give them advantage (these can be simple upgrades such as larger bullets, faster player, etc)
*
* */




using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


	// all added in the inspector
	
	
	public Player player;
	public Image a1, a2, a3;
	public Text scoreText;
	private int score;


	//for obstical 
	//private GameObject cylinder;
	

	//will instantiate enemies
	public Enemy enemy_blue, enemy_dark;
	
	
	//the only purpose of this boolean is to fix my playerLives method
	private bool isGameOver;

	

	// Use this for initialization
	void Start ()
	{

		
		isGameOver = false;
		score = 0;
		
		//invoke Only in Start() to avoid instanciating at each frame "Update()"
		InvokeRepeating("SpawnEnemies",1.5f,5f);//that's a pretty cool method 
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		playerLives();
		EndGame();
		
		
		//moveObstical();
		
		restartGame();
		
	}

	void playerLives()
	{

		if (!isGameOver)
		{


			switch (player.lives)
			{
				case 3:
					return;
				case 2:
					a1.enabled = false;
					break;
				case 1:
					a2.enabled = false;
					break;
				default:
					a3.enabled = false;
					//light error
					//keep trying to access the object when destroy...
					//fix it with isGameOver
					Destroy(player.gameObject);
					print("YOU LOSE");
					scoreText.text = "YOU LOSE (press R to restart) \nScore: " + this.score;
					isGameOver = true;
					break;
			}

			
		}

	}
	
	public void AddScore(int score)
	{

		this.score += score;
		scoreText.text = "Score: " + this.score;

	}

	
	void EndGame()
	{
		if (score >= 100)
		{
			//TODO not perfect I need another way to keep track of enemies destroyed
			scoreText.text = "YOU WIN\nEnemyDestroyed: " + this.score/5 ;
		}
		
	}

	// border limits x 50 z 60
	void SpawnEnemies()
	{
		float randomValueX = Random.Range(-20f, 20f);
		int randomEnemies = Random.Range(0,2);// 0,3 for adding obstical

		//temp.position = new Vector3(randomValueX, 0f, 0f);


		switch (randomEnemies)
		{
//			case 2:
//				
//				cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
//				Instantiate(cylinder, new Vector3(randomValueX, 0f, 30f),Quaternion.identity);
//				cylinder.AddComponent<Rigidbody>();
//				Rigidbody rb = cylinder.GetComponent<Rigidbody>();
//				rb.AddForce(Vector3.back, ForceMode.Acceleration);
//				
//				
//				
//				break;
//				
			case 1:
				Instantiate(enemy_blue, new Vector3(randomValueX, 0f, 30f), enemy_blue.transform.rotation );
				break;
			case 0:
				Instantiate(enemy_dark, new Vector3(randomValueX, 0f, 30f), enemy_dark.transform.rotation );
				break;
				
			default:
				return;
			// no need of break statement here
				
		}
		


	}

//	void moveObstical()
//	{
//		if(cylinder != null)cylinder.transform.Translate(Vector3.back);
//		
//	}
	
	
	
	
	void restartGame()
	{
		
		if( Input.GetKeyDown(KeyCode.R) )
		{
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}
	}

}
