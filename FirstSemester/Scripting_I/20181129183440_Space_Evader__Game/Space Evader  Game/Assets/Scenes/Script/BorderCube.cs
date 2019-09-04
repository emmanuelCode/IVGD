using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
	void OnTriggerExit(Collider other)
	{

		print("exited cube");
		Destroy(other.gameObject);
		
	}
	
	
	
}
