using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO to need to add physic material for bounciness inside box collider to all wall paddles etc. 
public class Ball : MonoBehaviour {
	
	private float ballInitialVelocity = 200f;


	private Rigidbody rb;
	
	// a bool to run our update code once
	private bool isBallInPlay;
	

	// Use this for initialization
	void Awake ()
	{
		

		rb = GetComponent<Rigidbody>();
		

	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		//TODO fix this code... ball go off course... 
		if (Input.GetKey(KeyCode.Space) && isBallInPlay == false)
		{
			transform.parent = null;
			isBallInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
		
		// doesn't work very well, the rest of the Code doesn't work such as Green Block not disappearing
		spawnBall();


		
	}


	private void OnCollisionEnter(Collision other)
	{
		//ballInitialVelocity += 1f;
		
		//add Speed to the ball 
		rb.AddForce(rb.velocity + new Vector3(0.05f,0.05f,0));

		print(rb.velocity);
	}


	//TESTING
	void spawnBall()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{

			Instantiate(gameObject);



		}

		
		
	}
}
