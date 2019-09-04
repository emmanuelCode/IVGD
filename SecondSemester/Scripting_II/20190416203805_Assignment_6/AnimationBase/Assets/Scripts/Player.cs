using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            anim.Play("WAIT01",-1,0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            anim.Play("WAIT02",-1,0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
            anim.Play("WAIT03",-1,0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            
            anim.Play("WAIT04",-1,0.0f);
        }

        if (Input.GetMouseButton(0))
        {
            anim.Play("DAMAGED00");
        }
        if (Input.GetMouseButton(1))
        {
            anim.Play("DAMAGED01");
        }



        float inputV = Input.GetAxis("Vertical");
        float inputH = Input.GetAxis("Horizontal");
        
        anim.SetFloat("inputV" ,inputV);//link to my animator variable controller(float)
        anim.SetFloat("inputH", inputH);//does change in the animator


        bool run = Input.GetKey(KeyCode.LeftControl);
        
        anim.SetBool("run",run);
        anim.SetBool("jump",Input.GetKey(KeyCode.Space));


        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if (moveZ <= 0)
        {

            moveX = 0;
            

        }
        else
        {
            if (run)
            {
                  moveX *= 3.0f;
                  moveZ *= 3.0f;
            }

        }

      GetComponent<Rigidbody>().velocity = new Vector3(moveX,0,moveZ);

    }
    
    
    
}
