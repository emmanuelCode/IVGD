using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Windows.Speech;


//TODO my plan instanciate enemies from the top at random location 
//TODO must instanciate two different kind of color
public class Enemy : MonoBehaviour
{

	public GameObject dark_enemy_bullet, blue_enemy_bullet;

	private GameManager gameManagerObject;

	//TODO trying to fix my live system "blackPlane doesn't goes along with lives variable "
	private Dictionary<String, int> enemies;
	

	// Use this for initialization
	void Start ()
	{

		gameManagerObject = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		// this will allow automatic shooting from enemies in certain time frame
		InvokeRepeating("enemyShooting",1f,1f);
		
		enemies = new Dictionary<string, int>();
		
		// unfinished... 
		enemies.Add("dark_enemy", 1);
		enemies.Add("blue_enemy", 1);
		//enemi
		


	}
	
	// Update is called once per frame
	void Update()
	{


		//for testing etc...
		//testEnemyBullet();
	
		transform.Translate(Vector3.back/10);

	}



	//TODO here I need to check if we got destroy by a bullet
	//TODO must fix the blue one setting enemy
	void OnTriggerEnter(Collider col)
	{
		//it touching the border...at the beginning...
		if (col.tag == "border_cube")
		{
			print("compared_tag");
			return;
		}

		if (col.tag == "blue_bullet")
		{
			// will need to add game manager here
			gameManagerObject.AddScore(5);
			Destroy(gameObject);
			print("destroide by blue");
		
			
			
			
		}
		
		//isTrigger must be enable in the inspector for the bullet to destroy it
		if (col.tag == "dark_bullet")
		{
		
			gameManagerObject.AddScore(5);
			Destroy(gameObject);
			print("destroide by dark");
			

		}



		//?????? don't remember why I was checking this....
		if (col.tag == "Player")
		{
			Destroy(gameObject);
			print("destroide by player");
			
		}
		

		
		//Destroy(gameObject);
		//print("I'm not supposed to print");//this run first...
	}




	
	// instanciate bullets
	//TODO need to position better
	void enemyShooting()
	{
		if (gameObject.CompareTag("dark_enemy"))
		{
			Instantiate(dark_enemy_bullet, transform.position - new Vector3(1f,0f,3f), transform.rotation);

		}
		else
		{
			Instantiate(blue_enemy_bullet, transform.position - new Vector3(1f, 0f, 3f), transform.rotation);
		}


	}


	//testing....
	void testEnemyBullet()
	{
		
		if (Input.GetKeyDown(KeyCode.E))
		{
			
			enemyShooting();
		}

	}


}
