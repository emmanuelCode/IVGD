using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOutOfRadius : MonoBehaviour
{
    public Transform target;
    public float radius;

    public bool useLateUpdate;

/*    [Space(10)]
    public bool useMaximumY = false;
    public float maximumY;*/

    // Update is called once per frame
    void Update()
    {
        if (useLateUpdate)
        {
            return;
        }
        StayOutOfRadiusUpdate();
    }

    // Update is called once per frame after every scene's object's Update
    void LateUpdate()
    {
        if (!useLateUpdate)
        {
            return;
        }
        StayOutOfRadiusUpdate();
    }

    void StayOutOfRadiusUpdate()
    {
        if (!target)
            return;

        Vector3 fromTargetDeltaPos = transform.position - target.position;

        if (fromTargetDeltaPos.magnitude < radius)
        {
            Vector3 fromTargetDeltaPosNormalized = fromTargetDeltaPos.normalized;
            transform.position = target.position + fromTargetDeltaPosNormalized * radius;

            if (gameObject.GetComponent<Rigidbody>())
            {                
                gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity - Vector3.Project(gameObject.GetComponent<Rigidbody>().velocity, fromTargetDeltaPosNormalized);
            }
        }

/*        //Then whether we have adjusted the pos or not, we check if we need to rescpect a maximum value for Y position.
        //We also validate that the actual position is more that the maximum value. 
        if (useMaximumY && transform.position.y > maximumY)
        {
            //Being in that scope means that we must set the Y position to maximumY value
            //We can't simply change Y position like that :----> transform.position.Y = maximumY;
            //So we need to create a new Vector3 with the wanted values, and then store it as being our transform.position.
            transform.position = new Vector3(transform.position.x, maximumY, transform.position.z);
        }*/
    }
}
