using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachTargetConstantSpeed : MonoBehaviour
{
    public Transform target;
    public float translationSpeed;
    public float rotationSpeed;

    bool isReaching;                        //This tels the script if it is in progress reaching the target.
    public bool attachToTargetWhenReached;  //This says if we need to attach or not to the target once reached.
    

    //Awake is called when the script is created. Awake is called before Start, it's a good place to initialize values.
    private void Awake()
    {
        //We set isReaching to false, it will be set to true only when SetInitialValue will be called.
        isReaching = false;
    }

    public void SetInitialValue(Transform pTarget, float pTranslationSpeed, float pRotationSpeed, bool pAttachToTargetWhenReached)
    {
        //This is the avtivation fucntion. Once everytnhing is setted, Updae will be able to complete the task.
        target = pTarget;                                       //We set the target.
        translationSpeed = pTranslationSpeed;
        rotationSpeed = pRotationSpeed;
        attachToTargetWhenReached = pAttachToTargetWhenReached; //We set if we must attach to the target once reached or not.

        isReaching = true;    //We set isReaching to true so that Update can do its job.
    }

    // Update is called once per frame
    void Update()
    {
        //If is reaching is not set to true, Update must not be executed, so we have to safely exit the fucntion using "return"
        if (!isReaching)
            return;
        

        isReaching = false;
        if (target.transform.position != transform.position)
        {
            isReaching = true;
            Vector3 deltaPos = target.transform.position - transform.position;
            float desiredTranslationLength = translationSpeed * Time.deltaTime;
            if (deltaPos.sqrMagnitude > desiredTranslationLength * desiredTranslationLength)
            {
                desiredTranslationLength = deltaPos.magnitude;
            }
            transform.Translate(deltaPos.normalized * desiredTranslationLength);
        }
        if (target.rotation != transform.rotation)
        {
            isReaching = true;
                
            float deltaAngle = Quaternion.Angle(transform.rotation, target.rotation);
            float desiredAngle = Mathf.Min(rotationSpeed, deltaAngle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, desiredAngle);
        }
                            
        //If reaching has been set to false
        if (!isReaching)
        {
            //We check of attachToTargetWhenReached feature is activated or not.
            if (attachToTargetWhenReached)
            {
                //If it is, we set target as being our gameObject's parent.
                transform.parent = target;
            }
            SendMessage("OnReachTargetConstantSpeedDone", SendMessageOptions.DontRequireReceiver);
            //Job done !! Now time to auto-destroy the script.            
            Destroy(this);

        }
    }
}
