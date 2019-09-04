using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionWithCollider : MonoBehaviour
{
    public GameObject targetToIgnore;
    // Start is called before the first frame update
    void Start()
    {     
        Physics.IgnoreCollision(targetToIgnore.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
