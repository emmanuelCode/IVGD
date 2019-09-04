using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null)
		{
			playerBall.HealthPotionAquired();

			Destroy(this.gameObject);
		}
	}
}
