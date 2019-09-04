using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {
	
	
	private List<GameObject> greenCubes;

	// Use this for initialization
	void Start () {
		
		
		generateGreenCube();
	}
	
	
	
	void generateGreenCube() {

		greenCubes = new List<GameObject>();
      
		for (int i = 0; i < 10; i++) {

			float x = Random.Range(-12.5f, 12.5f);
			float z = Random.Range(-12.5f, 12.5f);


			greenCubes.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

			greenCubes[i].transform.position = new Vector3(x,2,z);

			greenCubes[i].GetComponent<Renderer>().material.color = Color.green;
			
			greenCubes[i].GetComponent<Collider>().isTrigger = true;



		}



	}
	
	
	// Update is called once per frame
	void Update () {
		
		
	}


	
	
	
}
