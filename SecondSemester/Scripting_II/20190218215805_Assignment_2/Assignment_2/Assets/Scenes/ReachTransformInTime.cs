using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachTransformInTime : MonoBehaviour
{
//smooth means to transition slowly
    
    
    public Transform target;

    public float reachingTime;

    private Transform initialTransform;

    public bool isReaching;


    private Vector3 initialPosition;
    private Quaternion initialRotation;
      float initialTime;

      private bool attachToTarget;
    private void Awake()
    {
        isReaching = false;
        attachToTarget = false;
    }

  
    public void InitReaching(Transform pTarget, float pReachingTime, bool pAttachToTarget)
    {

        initialTime = Time.time;
        initialTransform = transform;


        initialPosition = transform.position;
        initialRotation = transform.rotation;
        

        
        target = pTarget;
        reachingTime = pReachingTime;
        attachToTarget = pAttachToTarget;
        isReaching = true;

    }

   

    // Update is called once per frame
    void Update()
    {

        if (!isReaching)
        {
            return;
        }

        //float timeRatio = Time.time / (initialTime + reachingTime);
        float timeRatio = (Time.time - initialTime) / reachingTime;

        if (timeRatio > 1)
        {
            
            timeRatio = 1;
            isReaching = false;
        }

       
     
        
        transform.position =Vector3.Lerp(initialPosition, target.position, timeRatio);
        transform.rotation = Quaternion.Slerp(initialRotation, target.rotation, timeRatio);

        if (timeRatio >= 1)
        {

            if (attachToTarget)
            {

                transform.parent = target;
            }
            
            Destroy(this);
        }


    }
}
