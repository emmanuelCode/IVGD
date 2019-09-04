using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null) {
			Time.timeScale = 0f;
			print("You Win!");
		}
	}
}
