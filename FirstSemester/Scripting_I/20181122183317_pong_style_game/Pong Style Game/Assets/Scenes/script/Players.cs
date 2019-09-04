//PROGRAMMING TASKS:
	
	//TODO get the paddle moving for both players(make limits so it does go off course) DONE...
	
	//TODO Colours of tiles are mapped to properties (like 1 hit to break, 2 hits to break, invincible) DONE...
	
	//TODO Speed of the ball changes based on the pad movement (use Rigidbody.AddForce()) DONE with velocity...
	
	//TODO Win screen when all tiles are destroyed (use https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html) DONE...
	
	//TODO If the ball falls into the kill zone at the bottom of the level, the player looses (when lives get to zero) DONE... 
	
	
	//TODO BONUS Features (1.5 points)
	//TODO Spawner that spawns the ball on the ball, the player decides when to release it //TODO basically create a method for it Getting There...
	//TODO Lives, when the player looses the ball, they loose a set amount of lives DONE...
	//TODO Cursor / Arrow that shows which direction the ball will go when spawned on the paddle. NOT DONE///
    
    //PROBLEMS ENCOUNTER (To ask the Teacher ):
    // when ball goes too fast it passes through objects, something to with Rigidbodies don't know how to fix it?????????
	// my paddles sometimes doesn't reflect the ball back and passes through. I also think is something to do with RigiBodies and the side of the paddle doesn't responds only the middle one does????
    // my spawn method work(had disable it in code) but turn my other code upside down...not working properly
    
    

    //PROGRAMMER NOTES:
	// I've use both linux (on my laptop ) and windows version(school desktop) to build the game.
	// both use latest version(2018.2.16f1)
    // for IDE I've used JetBrain Rider(student version) witch is made for Unity,
    // the <<TODO>> comments highlight my tasks in blue inside the IDE and make it easier to see what important
    // the Lives Script holds IMPORTANT part of the Game 




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to restart our game 
using UnityEngine.SceneManagement;

///resources: https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/creating-a-breakout-game


//change camera color to hide background view
public class Players : MonoBehaviour
{

	private float playerLimitMin, playerLimitMax, playerSpeed;

	// can't store x value to a float :https://answers.unity.com/questions/188998/transformposition.html
	private Vector3 playerPosition;
	
	
	//Awake() function is before start function
	// Use this for initialization
	void Start ()
	{

		playerLimitMin = -5.732f;
		playerLimitMax = 5.723f;

		playerSpeed = 0.7f;



	}
	
	
	
	
	
	// TODO my own feature: press a button for extra speed for catching ball quickly.(no code on this yet) 
	// does the ball have a limit?
	// Update is called once per frame
	void Update ()
	{

		
		playerPosition = transform.position;
		
		
		//TODO verify witch player we have

		if (gameObject.name == "player_one")
		{
			
			//playerPosition -= Vector3.right;
			playerOneMovement();
			
			
			
		}

		if (gameObject.name == "player_two")
		{
			playerTwoMovement();
		}
		
		


		//something to do with struct need to reUpdate the variables
		transform.position = playerPosition;
		
		
		
		restartGame();

		

		
		
		




	}


	void playerOneMovement()
	{
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{

			playerPosition -=  (playerPosition.x > playerLimitMin) ? new Vector3(playerSpeed * extraSpeedMethod(Input.GetKey(KeyCode.UpArrow)), 0, 0) : Vector3.zero ;
			
			//transform.position -= Vector3.right;
			
			print("move..." + playerPosition.x);
			

		}
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
	        
	        playerPosition +=  (playerPosition.x < playerLimitMax) ? new Vector3(playerSpeed * extraSpeedMethod(Input.GetKey(KeyCode.UpArrow)), 0, 0) : Vector3.zero ;

	     
        }
		
	}

	void playerTwoMovement()
	{
		if (Input.GetKey(KeyCode.A))
		{
		
			//TODO could use clamp to limit position of the paddle 
			playerPosition -=  (playerPosition.x > playerLimitMin) ? new Vector3(playerSpeed * extraSpeedMethod(Input.GetKey(KeyCode.W)), 0, 0) : Vector3.zero ;
		}
        
		if (Input.GetKey(KeyCode.D))
		{
        		
			playerPosition +=  (playerPosition.x < playerLimitMax) ? new Vector3(playerSpeed * extraSpeedMethod(Input.GetKey(KeyCode.W)), 0, 0) : Vector3.zero ;

		}

		if (Input.GetKey(KeyCode.W))
		{
			
			
		}




	}




	void restartGame()
	{
		
		if( Input.GetKeyDown(KeyCode.R) )
		{
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}
	}



	float extraSpeedMethod(bool speedKeyCode)
	{

		switch (speedKeyCode)
		{
			case true:
				playerSpeed = 0.7f;
				return 1f;
			
			default:
				playerSpeed = 8f;
				return Time.deltaTime;
				
		}

		//slow movement at all time 
	return Time.deltaTime * 5;

	}





}


