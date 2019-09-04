using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent.gameObject.SendMessage("OnShovelFound");
        Destroy(gameObject);
    }
}
