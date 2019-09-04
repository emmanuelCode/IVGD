using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GameObject doorToRemove; //?? I don't get why it there since I can destroy it with "this.gameObject"

	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null) {
			if (playerBall.HasKey()) {
				// TODO consume key and open door //DONE
				
				playerBall.ConsumeKey();
				
				Destroy(this.gameObject);
				
				
			}
		}
	}
}
