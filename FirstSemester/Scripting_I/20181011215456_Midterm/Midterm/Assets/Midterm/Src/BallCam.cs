using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCam : MonoBehaviour {

	public Ball player;
	public float baseHeight = 1f; //no f ??
	public float distanceAwayFromPlayer = 5f;
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector3 playerPosition = new Vector3(this.player.transform.position.x, this.baseHeight, this.player.transform.position.z);
			this.transform.position = playerPosition - Vector3.right * this.distanceAwayFromPlayer + Vector3.up * this.distanceAwayFromPlayer * 0.5f;
			this.transform.LookAt(this.player.transform);
		}
	}
}
