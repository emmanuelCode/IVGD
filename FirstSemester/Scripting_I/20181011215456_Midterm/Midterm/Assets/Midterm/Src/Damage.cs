using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public int damage = 2;

	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null) {
			// TODO subtract healthpoints equal to the damage value from the player  //DONE
			playerBall.healthPoints -= damage;
			
			print(playerBall.healthPoints); // couldn't keep track of health
		}
	}
}
