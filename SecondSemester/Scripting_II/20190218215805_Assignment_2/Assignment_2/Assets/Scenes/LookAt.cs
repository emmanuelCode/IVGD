using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    public Transform target;

    public bool useLateUpdate;


    public bool useDamping;
    public float damping;



    // Update is called once per frame
    void Update()
    {
        if (!useLateUpdate)
        {
            NormalUpdate();
        }
    }

    //last frame after Update
    void LateUpdate()
    {
       // gameObject.transform.rotation = Quaternion.LookRotation(target.position - gameObject.transform.position, Vector3.up);

        if (useLateUpdate)
        {
            NormalUpdate();
        }

    }
    void NormalUpdate()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        
        
        if (!useDamping)
        {

            transform.rotation = desiredRotation;
        }
        else
        {

            
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, damping * Time.deltaTime);

        }

        
        
        
        
        
    }



    


}
