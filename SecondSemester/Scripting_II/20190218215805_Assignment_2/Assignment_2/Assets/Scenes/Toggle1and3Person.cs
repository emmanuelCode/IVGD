using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle1and3Person : MonoBehaviour
{
    public Transform firstPersonAnchor;
    private bool is3rdPerson;
    // Start is called before the first frame update
    void Start()
    {
        is3rdPerson = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (is3rdPerson && Input.GetKey(KeyCode.Alpha1))
        {
        Enable3rdPersonCameraScripts(false);
        AttachToFirstPersonAnchor();
        is3rdPerson = false;

        }
        else if(!is3rdPerson && Input.GetKey(KeyCode.Alpha3))
        {
            transform.SetParent(null,true);
            
            Enable3rdPersonCameraScripts(true);
           ReachTransformInTime reachTransformInTime = gameObject.GetComponent<ReachTransformInTime>();
           if (reachTransformInTime)
           {
               Destroy(reachTransformInTime);
           }

           is3rdPerson = true;

        }
    }

    void AttachToFirstPersonAnchor()
    {




        ReachTransformInTime reachTransformInTime = gameObject.AddComponent<ReachTransformInTime>();
        reachTransformInTime.InitReaching(firstPersonAnchor, 1.0f, true);
        
        /* transform.parent = firstPersonAnchor;
         transform.localPosition = Vector3.zero;
         transform.localRotation = Quaternion.identity;*/
    }


    void Enable3rdPersonCameraScripts(bool enable )
    {
        
            LookAt lookAt = GetComponent<LookAt>();
           
            if (lookAt)//if it not null
            {
                
                lookAt.enabled = enable;
                
            }

            FollowPosition followPosition = GetComponent<FollowPosition>();
            
            if (followPosition)//if it not null
            {
                
                followPosition.enabled = enable;
                
            }

            StayWithinARadius stayWithinARadius = GetComponent<StayWithinARadius>();

            if (stayWithinARadius)//if it not null
            {
                
                stayWithinARadius.enabled = enable;
                
            }

         }
    
    
    
}
