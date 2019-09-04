using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    /*The goal of this script is to always tent to reach the position of a defined target.
     * We have the option to be updated by LateUpdate, which is very useful for camera because camera is better to be updated after all other scene's objects
     * We have the option to use a damping on the "look at" to give it a litle smoothness*/


    public Transform target;    //This will be the actual target to look at it
    public bool useLateUpdate;  //This says if we are updated in LateUpdate or not
    [Space(10)]                 //This is just a spacer to make it more appealing in the Inspector
    public bool useDamping;     //This says if we use a damping effect or not
    public float damping;       //This is the damping effect value

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
        //If not, then we proceed calling FollowTargetUpdate, where the actual script behavior is scripted.
        FollowTartgetUpdate();
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
        //If not, then we proceed calling FollowTargetUpdate, where the actual script behavior is scripted.
        FollowTartgetUpdate();
    }

    void FollowTartgetUpdate()
    {
        //This function is the core of that script. It's here that Follow Target behavior is scripted.
        //Since we can't follow a null target, we must validate that target is not null
        if (!target)
        {
            //If it's null, then we safely exit the function.
            return;
        }

        if (useDamping)
        {
            //Ok, we need to use damping. So we Slerp our way toward target.position using the damping value.
            transform.position = Vector3.Lerp(transform.position, target.position, damping * Time.deltaTime);
        }
        else
        {
            //Damping is not required, so we straightly set our position to the target.position.
            transform.position = target.position;
        }        
    }
}
