using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

	
	public int lives = 3;
	
	//added material in the inspector
	public Material blue,dark;

	public GameObject blue_bullet,dark_bullet;

	private Renderer[] allChildrenRenderers;


	private bool isShipTransform,isTwinBullet;

	private float rotationAnimation;

	private float turningTime;
	
	// Use this for initialization
	void Start ()
	{

	
		

		isShipTransform = false;
		isTwinBullet = false;
		allChildrenRenderers = GetComponentsInChildren<Renderer>();
		transform.position = new Vector3(0,0,-10);
	
		
	
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{

			
		//gameObject.transform.parent.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(0,0,0)), Quaternion.Euler(new Vector3(0,0,180)),Time.deltaTime * 0.1f) ;

		
		shipMovement();
		shipMode();
		shootBullets();

		if(Input.GetKeyDown(KeyCode.T))
		{
			if (!isTwinBullet)
			{
				isTwinBullet = true;
			}
			else
			{
				isTwinBullet = false;
			}
		}


	}

	void shipMode()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{

			switch (!isShipTransform)
			{
				case true:
					print("dark");
					isShipTransform = true;
					foreach (var renderers in allChildrenRenderers)
					{
						renderers.material = dark;
					}
					break;
				default:
					print("blue");
					isShipTransform = false;
					foreach (var renderers in allChildrenRenderers)
					{
						renderers.material = blue;
					}
					break;
					
			}
			
		
			
		}
		
		
	}






	// move between -20/20
	void shipMovement()
	{
		//get movements inputs
		float horizontalMovement = Input.GetAxis("Horizontal");
		float verticalMovement = Input.GetAxis("Vertical");

		
		//get x position and add Input horizontal Axis (-1,1) * speed(0.9f)
		float xPos = transform.position.x + horizontalMovement ;
		float zPos = transform.position.z + verticalMovement;
		
		//set the limit with Clamp 
		float horizontalLimits = Mathf.Clamp(xPos, -20f, 20f);
		float verticalLimits = Mathf.Clamp(zPos, -20f, 30f);
		
		transform.position = new Vector3( horizontalLimits,0, verticalLimits) ;

		
		//rotationShipTransform();
		
		//transform.rotation = Quaternion.Euler(0,0, Mathf.Clamp(transform.rotation.z	+ horizontalMovement * -100f,-20f,20f));
		transform.rotation = Quaternion.Euler(0,0, transform.rotation.z + /*rotationAnimation*/ + horizontalMovement * -20f);

		
		
	}

	void shootBullets()
	{
		if (Input.GetButtonDown("Fire1")|| Input.GetKeyDown(KeyCode.Space))
		{
			BulletType();
		}
	}



	
	void BulletType()
	{
		//nested if statement should there be a better way......?
		if (!isShipTransform)
		{
			if (isTwinBullet)
			{

				Instantiate(blue_bullet, transform.position + new Vector3(1.20f,0, 2.5f), transform.rotation);   
		        Instantiate(blue_bullet, transform.position + new Vector3(-1.20f,0, 2.5f ), transform.rotation);
				
			}
			else
			{
			    Instantiate(blue_bullet, transform.position + new Vector3(0,0, 2.5f ), transform.rotation);

			}



		}
		else
		{
			if (isTwinBullet)
			{
				
				Instantiate(dark_bullet, transform.position + new Vector3(1.20f,0, 2.5f ), transform.rotation);
				Instantiate(dark_bullet, transform.position + new Vector3(-1.20f,0, 2.5f ), transform.rotation);

			}
			else
			{
				
				Instantiate(dark_bullet, transform.position + new Vector3(0,0, 2.5f ), transform.rotation);
			}

			
			
		}	
		
	}
	

	// prototype method
//	void rotationShipTransform()
//	{
//		if (rotationAnimation < transform.position.z + 180f)
//		{
//			rotationAnimation += 5f *Time.deltaTime;
//		}
//		else
//		{
//			rotationAnimation = 180f;
//		}
//
//	}


	//TODO test some more for this method...
	//if anything touches a player with rigibodies(with no kinematic) it does .....
	private void OnCollisionEnter(Collision col)
	{
			
		//remove lives
		lives--;
        print("lives:" + lives);
		
		//doesn't work well with OnTriggerEnter so this is my solution for the enemy destruction
		//destroy the colliding object
		Destroy(col.gameObject);
		

		

	}

}
