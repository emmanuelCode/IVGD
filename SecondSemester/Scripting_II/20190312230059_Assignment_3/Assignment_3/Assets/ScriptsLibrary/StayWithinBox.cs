using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithinBox : MonoBehaviour
{
    public BoxCollider boxCollider;
    public bool useLateUpdate;  //This says if we are updated in LateUpdate or not.
    public bool affectX;
    public bool affectY;
    public bool affectZ;    

    // Update is called once per frame
    void Update()
    {
        //If the designer has checked useLateUpdate, then we shoud not use Update...
        //Check if useLateUpdate is true
        if (useLateUpdate)
        {
            //If it's true, then we must exit the function.
            return;
        }
        //If not, then we proceed calling StayWithinARadiusUpdate, where the actual script behavior is scripted.
        StayWithinBoxUpdate();
    }

    // Update is called once per frame after every scene's object's Update.
    void LateUpdate()
    {
        //If the designer doesn't have checked useLateUpdate, then we shoud not use LateUpdate...
        //Check if useLateUpdate is false
        if (!useLateUpdate)
        {
            //If it's false, then we must exit the function.
            return;
        }
        //If not, then we proceed calling StayWithinARadiusUpdate, where the actual script behavior is scripted.
        StayWithinBoxUpdate();
    }

    // Update is called once per frame
    void StayWithinBoxUpdate()
    {
        Vector3 desiredPos = boxCollider.ClosestPoint(transform.position);

        if (!affectX) desiredPos.x = transform.position.x;
        if (!affectY) desiredPos.y = transform.position.y;
        if (!affectZ) desiredPos.z = transform.position.z;

        transform.position = desiredPos;
    }
}
