using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBlock : MonoBehaviour {


	private void OnCollisionEnter(Collision other)
	{
		print("I cannot be destroyed");
	}
}
