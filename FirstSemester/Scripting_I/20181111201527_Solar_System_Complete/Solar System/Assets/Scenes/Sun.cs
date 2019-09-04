using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

	public Manager manager;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * (manager.speed + 10));
	}
}
