using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null) {
			playerBall.CoinAquired();

			Destroy(this.gameObject);
		}
	}
}
