using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null) {
			// TODO Kill playerball
			if (playerBall.healthPoints <= 0)
			{
				
			Destroy(playerBall.gameObject);
			}
		}
	}
}
