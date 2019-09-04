using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBlock : MonoBehaviour {

	
	private int blockLives;
	
	// Use this for initialization
	void Start ()
	{

		blockLives = 3;

	}

	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.name == "ball")
		{
			
			checkLives();
			print("GreyBlockLives: " + blockLives);


		}

		
		
	
	
	}


	void checkLives()
	{
		if (blockLives != 0)
		{
        
			blockLives--;
        
		}
        		
		if(blockLives == 0)
		{
        			
			Destroy(gameObject);
		}
		
	}
}
