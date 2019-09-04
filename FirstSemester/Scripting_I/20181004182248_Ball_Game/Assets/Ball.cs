using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float strength = 1f;
    public int healthPoint = 10;
    public int collectibles = 0;

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent("Rigidbody") as Rigidbody;

        //if (Input.GetKey(KeyCode.Space)){
        // rb.AddTorque(Vector3.forward * strength);
        //}

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddTorque(Vector3.forward * strength);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddTorque(Vector3.back * strength);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb.AddTorque(Vector3.left * strength);


        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            rb.AddTorque(Vector3.right * strength);

        }


        //TEST CASE
        if (Input.GetKey(KeyCode.W))
        {
            ballWins(GetComponent<Collider>());
        }


        if (Input.GetKey(KeyCode.L))
        {
            ballLose();
            
           
        }



    }

    
    
    
   
    
    /**
     * overriding the OnTriggerEnter Method
     * 
     */

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {

           healthPoint -= 1;
            
           print("OUCH " + healthPoint + " HP LEFT!!!");


            // if heathPoint reaches zero we lose and so we get destroy
            if (healthPoint == 0)
            {
                ballLose();
            }




        }
        else 
        {
            collectibles += 1;

            print("COLLECTED " + collectibles + " GREEN_CUBE");
            
            Destroy(other.gameObject);

            //if we collect 10 green cube then we win
            if (collectibles == 10)
            {
                ballWins(other);
            }

        }


    }
    
    
    
    void ballWins(Collider other)
    {
        //a way to access my field in other classes
        EnemiesSpaw e = other.GetComponent("EnemiesSpaw") as EnemiesSpaw;
        
        
        print("BALL WINS!");

        foreach (GameObject elements in e.redCubes)
        {
           
            //destroy redcubes when winning
            Destroy(elements);
          
        }

        
     }


    void ballLose()
    {
        
        print("BALL LOSE!");
        
        //destroy ball
        Destroy(this.gameObject);
        
        
       
    }




}