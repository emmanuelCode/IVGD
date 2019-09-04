using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour
{

    private Gun gun;
    private Quaternion initialRotation, wantedRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        //get the gun script
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        
        //current rotation of the transform object
        initialRotation = transform.rotation;//localRotation???
         
        //position
        wantedRotation = Quaternion.Euler(new Vector3(0, 0, 0));
       
        
        print("safety ping" + gun.safetyPin);

    }

    // Update is called once per frame
    void Update()
    {

        //do a rotation while holding the right mouse key
        if (Input.GetKey(KeyCode.Mouse1))
        {
           transform.localRotation = Quaternion.Slerp(transform.localRotation, wantedRotation, Time.deltaTime * 10);
           gun.safetyPin = false;

        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(90, 0, 0)), Time.deltaTime * 10);
            gun.safetyPin = true;
            
        }



  

    }
}
