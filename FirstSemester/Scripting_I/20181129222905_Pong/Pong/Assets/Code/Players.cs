using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Players : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		movePlayersOne();
		movePlayerTwo();
	}


	void movePlayersOne()
	{
		//int playerSpeed = 1;

		if (gameObject.name == "Player_one")
		{
			
			if (Input.GetKey(KeyCode.W))
            		{
            						
			            transform.position += transform.position.y >= 29f ? Vector3.zero  : Vector3.up;
            			
            		}
            
            		if (Input.GetKey(KeyCode.S))
            		{
            			
			            transform.position += transform.position.y <= -29f ? Vector3.zero  : Vector3.down;
            		}

			
		}
		

		
		
		

		
//
//		float playerY = transform.position.y + (Input.GetAxis("Vertical") * playerSpeed);
//		float playerX = transform.position.x;
//		
//		Vector3 playerPos = new Vector3 (playerX, Mathf.Clamp (playerY, -8f, 8f), 0f);
//		
//		transform.position = playerPos;

		
		
		
	}




	void movePlayerTwo()
	{
		
		if (gameObject.name == "Player_two")
		{
			
			if (Input.GetKey(KeyCode.UpArrow))
			{
            						
				transform.position += transform.position.y >= 29f ? Vector3.zero  : Vector3.up;
            			
			}
            
			if (Input.GetKey(KeyCode.DownArrow))
			{
            			
				transform.position += transform.position.y <= -29f ? Vector3.zero  : Vector3.down;
			}

			
		}

	}



}
