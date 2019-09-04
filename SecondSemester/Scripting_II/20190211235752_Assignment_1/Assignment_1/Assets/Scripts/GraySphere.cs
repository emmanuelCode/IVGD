using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraySphere : MonoBehaviour
{
   // public float speed = 1f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A)) {

           
            if (Input.GetKeyUp(KeyCode.B)) {

                transform.Translate(Vector3.left );
            }
            

            if (Input.GetKeyDown(KeyCode.B)) {

                transform.Translate(Vector3.right );

            }


        }
        
    }
}
