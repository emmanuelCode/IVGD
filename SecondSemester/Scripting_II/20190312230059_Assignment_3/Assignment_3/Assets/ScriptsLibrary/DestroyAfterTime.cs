using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    /*This scipt goal is to destroy an object after a timer. 
     * By code, it's simpler to use Destroy(gameObject, lifeTime); directly instead of instanciatiing an instance of this script to do the same job....
     * But it can be usefull for object that are created already with it as component.
     */
     
    public float lifeTime;  //The before the object should be destroyed
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);     //Call Destroy function in start passing it lifeTime. It will do all the job for us.
    }    
}
