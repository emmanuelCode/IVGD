using System;//needed this for my Array class to work
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntArray : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //generate an array that will hold 10 value
        int[] myArray = new int[10];

        

        //a loop that iterate or repeat the code block
        for (int i = 0; i < myArray.Length; i++) {

            //assign values each element of myArray using random number
            myArray[i] = UnityEngine.Random.Range(0, 100); //for me I needed to specify the UnityEngine in front

            //use the print function for test case 
            //print(myArray[i]);

        }//end of loop after 10 times

        //sorted myArray with this function passing my array through as parameter"()"
        Array.Sort(myArray);

        // used my custom fuction to print it in one line 
        sortedArrayInOneLine(myArray);




	}

    /*
    * this is my own custom function to print it in one line
    * takes an array as parameter
    */
    void sortedArrayInOneLine(int[] passedArray) {

        // an empty string 
        string outputInOneLine = "";

        // loop that will iterate or repeate the code block
        for (int i = 0; i < passedArray.Length; i++) {

            //if value of i is equal to the length of the Array minus one "( 10 - 1 = 9)"
            if (i == passedArray.Length - 1)
            {
                //we assign the value of the array element plus a dot   
                outputInOneLine += passedArray[i] + ".";

            }
            else {
                
                //we assign the value of the array element plus a comma
                outputInOneLine += passedArray[i] + ",";

            }

        }//end a loop after 10 times

        // we print our string after the loop
        print(outputInOneLine);
    }


  
	
	// Update is called once per frame
	void Update () {
		
	}


}
