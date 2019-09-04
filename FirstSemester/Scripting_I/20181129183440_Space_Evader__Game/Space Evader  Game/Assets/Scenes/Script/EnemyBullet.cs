using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.back);

		//bug fix for bullet bypassing border_cube limits
		if (transform.position.z < -400f)
		{
		
			print("bullet passed the boundery and got destroyed");
			Destroy(gameObject);
		}

	}
}
