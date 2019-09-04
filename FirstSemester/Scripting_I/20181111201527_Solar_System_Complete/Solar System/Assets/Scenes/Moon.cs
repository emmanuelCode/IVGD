using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;

// this is my answer for the moon script: https://answers.unity.com/questions/12301/how-can-i-get-a-parent-gameobject-of-gameobject-us.html
public class Moon : MonoBehaviour
{


	//public PlanetClass planet;
	public int speed;
	//private Vector3 position;
	//private Quaternion rotation;

	private GameObject parentGameOject;

	// Use this for initialization
	void Start ()
	{

		parentGameOject = transform.parent.gameObject;



	}
	
	// Update is called once per frame
	void Update () {
		
	
		
		// LOGIC OF THE MOONS:
		// 1. place the empty gameObject to same position such as earth
		// 2. make the empty gameObject a child of parent "earth -> emptyGameObject"
		// 3. make the Moon a child of empty gameObject "earth -> emptyGameObject -> Moon"
		
		// rotate the parent gameObject "emptyGameObject", should rotate around earth for example
		parentGameOject.transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * speed);
		
		// rotate the moon itself
		transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * speed);
		
		
		
		
		
		//position = planet.transform.position  + new Vector3(0,0,3);		
        		
        //transform.RotateAround(planet.transform.position, Vector3.up, Time.deltaTime * speed);
        		
		
		//rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * speed);
		
		//transform.SetPositionAndRotation(position,to);
		
		//transform.position = planet.transform.position + new Vector3(0,0,3);
	}
}
