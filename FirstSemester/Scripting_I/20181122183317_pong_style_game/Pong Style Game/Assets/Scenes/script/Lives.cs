using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;


/// <summary>
/// Lives will take care of managing the game. "just something I decided ;) "
/// </summary>
public class Lives : MonoBehaviour
{
//
//	public GameObject bricks;
//	private int numberOfBlock
//    bricks.transform.childCount 

	private int lives;
	
	//set inside unity inspector  
	public DeathZone deathZone;

	private Text livesText;


	//set inside unity inspector
	public GameObject endGameStatus, ball, bricks;

	// our text for when the game end
	private Text endGameStatusText;
	
	
	//TESTNG variable not being use now 
	// keep track of brickCount
	private int brickCounts;
	
	
	
	
	
	
	
	
	
	
	    
	// Use this for initialization
	void Start ()
	{

		lives = 3;

		//get Text from gameObject
		livesText = gameObject.GetComponent<Text>();

		//set text to number of Lives
		livesText.text = "Lives: " + lives;
		
		
		//setting text variable 
		endGameStatusText = endGameStatus.GetComponent<Text>();


		//TESTING
		//one brick is invincible so -1
		//brickCounts = bricks.transform.childCount -1;








	}

	private void Update()
	{
		
		if (deathZone.isCollidedWithBall)
		{
			lives--;

			livesText.text = "Lives: " + lives;

			deathZone.isCollidedWithBall = false;
			
			print(livesText.text);


			if (lives == 0)

			{
				//Destroy Ball
				Destroy(ball);
				
				
				//enable our Game Status Text
				endGameStatus.SetActive(true);
				endGameStatusText.text = "Game Over\nPlease Restart";
				
				
				

			}


		}


		//here you verify the number of bricks set it to 1 since one block is invincible 
		if (bricks.transform.childCount == 1)
		{
			endGameStatus.SetActive(true);
			//no need to  change endGameStatusText.text already preset to "You Win" in the inspector 
			
			//so we can't play anymore
			Destroy(ball);
			
		}

		//TESTING
		//keep track of brick for debugging //notice I didn't put -1
		print("numberOFBricks(BrickChildCount): " + bricks.transform.childCount);
		
		
		
		
	}
}
