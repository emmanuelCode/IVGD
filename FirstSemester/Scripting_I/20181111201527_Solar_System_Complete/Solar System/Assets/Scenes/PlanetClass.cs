using UnityEngine;

namespace Scenes
{
    public class PlanetClass: MonoBehaviour
    {

        
        public Manager manager;
        public string planetName;
	    //private Vector3 planetPositon;
	    

	    
	    

        //public float random;
        // Use this for initialization
        void Start ()
        {

	      //  planetPositon = transform.position;




        }
	
        // Update is called once per frame
        void Update () {
		
            transform.RotateAround(manager.sunPositon,Vector3.up, Time.deltaTime * manager.planetsInfo[planetName]);

            // why *= and not +=?
            transform.rotation *= Quaternion.Euler(Vector3.up * Time.deltaTime * manager.planetsInfo[planetName]);
		
		
        }
        


    }
}