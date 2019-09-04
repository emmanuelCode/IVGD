using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null && collision.rigidbody != null)
            collision.rigidbody.SendMessage("OnDamage", damage, SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
            other.gameObject.SendMessage("OnDamage", damage, SendMessageOptions.DontRequireReceiver);        
    }
}
