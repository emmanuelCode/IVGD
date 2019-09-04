using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delme : MonoBehaviour
{

    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         ReachTransformInTime reachTransformInTime  =  gameObject.AddComponent<ReachTransformInTime>();
         
         reachTransformInTime.InitReaching(target,10,true);
         
         Destroy(this);
            
                
        }
    }
}
