using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    bool onGround = false;
    public bool OnGround
    {
        get { return onGround; }     
    }

    int groundCount;
  
    private void Start()
    {
        if(gameObject.GetComponent<Collider>())
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {        
        onGround = true;
        groundCount += 1;
        SendMessageUpwards("OnGroundSensorDetection", SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerExit(Collider other)
    {        
        groundCount -= 1;
        if (groundCount <= 0)
        {
            onGround = false;
            groundCount = 0;
        }
    }
}
