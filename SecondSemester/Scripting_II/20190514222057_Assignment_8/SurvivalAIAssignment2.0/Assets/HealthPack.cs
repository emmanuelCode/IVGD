using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{	
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent.gameObject.SendMessage("Heal", 50.0f);
        Destroy(gameObject);
    }        
}
