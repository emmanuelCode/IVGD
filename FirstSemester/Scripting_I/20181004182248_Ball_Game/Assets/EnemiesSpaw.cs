using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpaw : MonoBehaviour {

    //global variables
    private GameObject redCube;
    
    //private float x, z;


    public List<GameObject> redCubes; 
	// Use this for initialization
	void Start () {

        generateRedCube();
	    
	    
	    
	    

        //set a range for board 
       // x = Random.Range(-12.5f, 12.5f);

       // z = Random.Range(-12.5f, 12.5f); 
       

        // creating game object as cube 
        //redCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //redCube.transform.position = new Vector3(x, 10, z);
        //redCube.GetComponent<Renderer>().material.color = Color.red;


        //Instantiate(redCube);

        //gameObject.renderer.material.color = Color.white;
        //gameObject.GetComponent<Renderer> ().material.color = Color.green;


        //   GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // cube.transform.position = new Vector3(0, 0.5f, 0);

    }


    void generateRedCube() {

        redCubes = new List<GameObject>();
      
        for (int i = 0; i < 20; i++) {

            float x = Random.Range(-12.5f, 12.5f);
            float z = Random.Range(-12.5f, 12.5f);


            redCubes.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

            redCubes[i].transform.position = new Vector3(x,2,z);

            redCubes[i].GetComponent<Renderer>().material.color = Color.red;

            redCubes[i].GetComponent<Collider>().isTrigger = true;



        }



    }


    void moveRedCubes() {
        
       
        foreach(GameObject elements in redCubes) {
            
            
            float randomRange = Random.Range(-1,1);

            //float currentPositionX = elements.transform.position.x;
            
   
            
            
            //float currentPositionZ = elements.transform.position.z;

            //float max = currentPositionZ + 3; 
            
           // elements.transform.Translate(Vector3.forward * Time.deltaTime * 1); 


            // algorithm to move redCubes(not as perfect)
            if (randomRange == -1)
            {
                
                elements.transform.Translate(Vector3.forward * Time.deltaTime * -1);
                elements.transform.Translate(Vector3.right * Time.deltaTime * -1);
                
            }
            else
            {      
                
                elements.transform.Translate(Vector3.forward * Time.deltaTime * 1);
                elements.transform.Translate(Vector3.right * Time.deltaTime * 1);


                
            }


               


            
            



            // if (currentPositionX < currentPositionX + 1)
           // {
            //     elements.transform.position = new Vector3( currentPositionX - randomRange, 3, currentPositionZ );
           // }
           // else if(currentPositionX > currentPositionX - 1)
           // {
           //      elements.transform.position = new Vector3( currentPositionX + randomRange, 3, currentPositionZ );
 
          //  }
           // elements.transform.Tr

            
            





        }



    }

    // Update is called once per frame
    void Update () {
        
       
        checkingBeforeMove();
        


		
	}

    void checkingBeforeMove()
    {
        foreach (GameObject elements in redCubes)
        {
            if(elements != null)
            moveRedCubes();
          
        }

       

    }






}
