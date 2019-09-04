using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzBuzz : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //a custom method I created that will execute by calling it name in the start function
        fizzBuzz();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
    * created a custom function  
    * this one takes no parameter "()"
    */
    void fizzBuzz(){

        
        int maxIterations = 1000; 
        
        //repeat a thousand times
        for (int i = 0; i < maxIterations; i++) {

            // ok the logic here...
            // modulus return the remainder example: 8 / 7 = 1.1428.. get the remainder of one decimal value with is 1 , when 14 / 7  = 2 then it a whole number no decimal value
            if (i % 7 == 0 && i != 0)
            {
                
                print(i + " fizz");


            }
            else if (i % 10 == 7) {//modulus 10 get the last number, example  857 % 10 = 7 


                print(i + " buzz");
            }




        }





    }
}
