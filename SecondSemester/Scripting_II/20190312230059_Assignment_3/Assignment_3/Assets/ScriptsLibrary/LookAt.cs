using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    /*The goal of that script is to make the gameObject look at a define target.
     * We have the option to be updated by LateUpdate, which is very useful for camera because camera is better to be updated after all other scene's objects
     * We have the option to use a damping on the "look at" to give it a litle smoothness*/

    public Transform target;    //This will be the actual target to look at it
    public bool useLateUpdate;  //This says if we are updated in LateUpdate or not
    [Space(10)]                 //This is just a spacer to make it more appealing in the Inspector
    public bool useDamping;     //This says if we use a damping effect or not
    public float damping;       //This is the damping effect value
    public bool useMaxSpeed;
    public float maxSpeed;
    public bool lookAway = false;  ///*NEW*/ This says if the look at should be reversed and "show object's back side" to target

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
        //If not, then we proceed calling LookAtUpdate, where the actual script behavior is scripted.
        LookAtUpdate();
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
        //If not, then we proceed calling LookAtUpdate, where the actual script behavior is scripted.
        LookAtUpdate();
    }

    void LookAtUpdate()
    {
        //This function is the core of that script. It's here that look at behavior is scripted.
        //Since we can't look at a null target, we must validate that target is not null
        if (!target)
        {
            //If it's null, then we safely exit the function.
            return;
        }

        //We store into wantedRotation the desire rotation.
        /*NEW*/// Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        /*NEW*/        
        /*NEW*/ Vector3 lookAtDesiredVector = target.position - transform.position;
        /*NEW*/ if (lookAway)
        /*NEW*/     // If we lookAway we reverse lookAtDesiredVector.
        /*NEW*/     lookAtDesiredVector *= -1;

        /*NEW*/ Quaternion wantedRotation = Quaternion.LookRotation(lookAtDesiredVector, Vector3.up);

        if(useMaxSpeed)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, wantedRotation, maxSpeed * Time.deltaTime);
        }
        //We check if we must use damping or not.
        else if (useDamping)
        {
            //Ok, we need to use damping. So we Slerp our way toward the wantedRotation using the damping value.
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, damping * Time.deltaTime);
        }
        else        
        {
            //Damping is not required, so we straightly set our rotation to the wantedRotation.
            transform.rotation = wantedRotation;
        }
    }    
}
