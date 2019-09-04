using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null) {
			playerBall.KeyAquired();
			Destroy(this.gameObject);
		}
	}
}
