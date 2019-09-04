using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Assigment_4 : MonoBehaviour
{
    
    public int nbNode;
    public List<int> myList;
    public int[] myArray, myListValueCount;
    public int total;
    public Dictionary<int, int> myDictionary;
    public List<Dictionary<string, float[]>> myListOfDictionariesOfFloatArray;
    
    // Start is called before the first frame update
    void Start()
    {
        //initialize my variables
       myList = new List<int>();
       myArray = new int[nbNode];
       myDictionary = new Dictionary<int, int>();
       myListOfDictionariesOfFloatArray = new List<Dictionary<string, float[]>>();

       for (int i = 0; i < nbNode; i++)
       {
           //myList must be filled by nbNode amount of integers randomly picked [0,nNode]
           myList.Add(Random.Range(0,nbNode));
           
           //myArray must be filled by nbNode amount of integers randomly picked [0,nNode]
           myArray[i] = Random.Range(0,nbNode);
           
           //myDictionary must be used to count instances of every number in myList
           myDictionary.Add(i, myList[i]);
           
           
       

       }

       for (int i = 0; i < myList.Count; i++)
       {
          
           //myListValueCount must contain the results stored in myDictionary

           //how many times my list contains x
           if (myDictionary.ContainsValue(myList[i]))
           {
               myListValueCount[i]++;

           }

           //sum of all values of myDictionnary
           total += myDictionary[i];



       }





       myListOfDictionariesOfFloatArray.Add(
           
           
           new Dictionary<string, float[]>()
           {
               {"first", new float[]{1.0f,4.5f, 7.4f}}
               
               
           }        
       
       
       );
       
       
       //print the second element of the above float list
       print(myListOfDictionariesOfFloatArray[0]["first"][1]);
       
     


    

}
    
    
}
