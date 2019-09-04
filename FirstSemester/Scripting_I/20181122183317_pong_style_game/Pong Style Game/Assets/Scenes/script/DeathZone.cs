using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

	public bool isCollidedWithBall;

	// Use this for initialization
	void Start ()
	{
		isCollidedWithBall = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "ball")
		{

			isCollidedWithBall = true;
			
			print("collided with ball?: " + isCollidedWithBall);
		}
	}
}
