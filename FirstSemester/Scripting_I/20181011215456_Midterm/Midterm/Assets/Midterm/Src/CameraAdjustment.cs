using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjustment : MonoBehaviour {

	public float newBaseHeight = 1f;

	void OnTriggerEnter (Collider other) {
		Ball playerBall = other.GetComponent<Ball>();
		if (playerBall != null) {
			BallCam ballCam = playerBall.ballCam.GetComponent<BallCam>();
			// TODO set baseHeight of ballcam to newBaseHeight //DONE

			ballCam.baseHeight = newBaseHeight;
		}
	}
}
