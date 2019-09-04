using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRotation : MonoBehaviour {

	private float random;

	// Use this for initialization
	void Start () {
		this.random = Random.Range(0f, 10000f);
	}

	// Update is called once per frame
	void Update () {
		
		
		// rotate the object around the Y axis continuously
		//this.transform.rotation = Quaternion.Euler(0,1,0) * Time.deltaTime ;
		
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,this.random ,0), Time.deltaTime);// this work halfway....

	}
}
