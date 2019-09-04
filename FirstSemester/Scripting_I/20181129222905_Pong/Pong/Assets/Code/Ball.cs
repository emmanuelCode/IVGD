using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	//forgot the bounciness in physic material and lost an hour
	
	private Rigidbody rb;

	public GameManager gameManager;
	
	private bool isBallInPlay;

	// Use this for initialization
	void Awake ()
	{

		rb = transform.GetComponent<Rigidbody>();
		
		
		
	}

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		
		startBall();
		ballLost();
		
	}



	void startBall()
	{

		if (Input.GetKey(KeyCode.Space) && isBallInPlay == false)
		{
			rb.isKinematic = false;
			rb.AddForce(new Vector3(600f, -600f, 0));
			isBallInPlay = true;

		}



	}
	
	
	
	private void OnCollisionEnter(Collision other)
	{
		// won't add any force on my ball...
		rb.AddForce(rb.velocity + new Vector3(1f,1f,0f));

		print(rb.velocity);
	}


	void ballLost()
	{
		if (transform.position.x <= -30)
		{
			gameManager.AddScoreToPlayerOne(1);
			restartBall();
			isBallInPlay = false;
		}

		if (transform.position.x >= 30)
		{
			
			gameManager.AddScoreToPlayerTwo(1);
			restartBall();
			isBallInPlay = false;
		}

	}


	//I restarted the ball at it original location
	//couldn't figure out with the logic quickly enough(for destroying and Instantiate) so I made restartBall instead  
	void restartBall()
	{
		transform.position = new Vector3(0f,30f,0f);
		rb.velocity = Vector3.zero;
	}

}
