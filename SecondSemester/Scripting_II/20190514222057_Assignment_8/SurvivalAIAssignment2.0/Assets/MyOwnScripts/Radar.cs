using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;



public class Radar 
{

    //static constants
    public const int SHOVEL = 0;
    public const int COIN = 1;
    public const int DIGGING_AREA = 2;
    public const int HEALTH_PACK = 3;
    
    
//    enum collectibles 
//    {
//        shovels,
//        coins,
//        diggingAreas,
//        healthPacks 
//    
//    }
//    haven't master enum just yet..
    
    private GameObject[] shovels;
    private GameObject[] coins;
    private GameObject[] diggingArea;
    private GameObject[] healthPacks;

   // public CapsuleCollider characterCollider;
    private GameObject character;

    //links the distance and value of one object type agaist the player
    private Dictionary<Vector3[], float[]> shovelsDictionnary;
    private Dictionary<Vector3[], float[]> coinsDictionnary;
    private Dictionary<Vector3[], float[]> diggingAreaDictionnary;
    private Dictionary<Vector3[], float[]> healthPacksDictionnary;


    private float colliderRadius;


    public Radar(Character character)
    {
        
        this.character = character.gameObject;
        
        
       
       //characterCollider = character.AddComponent<CapsuleCollider>();
       
       
       //colliderRadius = characterCollider.radius;
       
       
       updateGameObjects();

       
       

    }



    public void Scan()
    {
       updateGameObjects();
       
    }


//    private void Grow()
//    {
//        
//        if(colliderRadius != 32.5f)
//        {
//
//            colliderRadius++;
//
//        }
//
//    }
//    
    

//    //if done Growing shrink
//    public void Shrink()
//    {
//        colliderRadius = 0.5f;
//
//    }

    //will update my gameObjects Counts
    private void updateGameObjects()
    {
       
        
       shovels = GameObject.FindGameObjectsWithTag("Shovel");
       coins = GameObject.FindGameObjectsWithTag("Coin");
       diggingArea = GameObject.FindGameObjectsWithTag("DiggingArea");
       healthPacks = GameObject.FindGameObjectsWithTag("HealthPack");

       shovelsDictionnary = DistanceBetweenPlayer(shovels);
       coinsDictionnary = DistanceBetweenPlayer(coins);
       diggingAreaDictionnary = DistanceBetweenPlayer(diggingArea);
       healthPacksDictionnary = DistanceBetweenPlayer(healthPacks);


    }
    
    
    //this will also update at each call
    //get position and distance between the player and the gameObject 
    private Dictionary<Vector3[], float[]> DistanceBetweenPlayer(GameObject[] positions)
    {
        float[] tempFloats = new float [positions.Length];
        Vector3[] tempVector3s = new Vector3[positions.Length];
        
        Dictionary<Vector3[],float[]> tempDictionary = new Dictionary<Vector3[], float[]>();
        
        for (int i = 0; i < positions.Length; i++)
        {

           tempFloats[i] = Vector3.Distance(character.transform.position, positions[i].transform.position);
           tempVector3s[i] = positions[i].transform.position;
           
           
        }
                   Debug.Log(tempFloats);

        tempDictionary.Add(tempVector3s,tempFloats);//add one item to dictionnary..

        return tempDictionary; //position for one type..

    }


    public Vector3 getToTheNearest(int collectible)
    {

        
        switch(collectible)
        {
            case Radar.SHOVEL:
                return closestTarget(shovelsDictionnary);
                break;
            case Radar.COIN:
                return closestTarget(coinsDictionnary);
                break;
            case Radar.HEALTH_PACK:
                return closestTarget(healthPacksDictionnary);
                break;
            case Radar.DIGGING_AREA:
                return closestTarget(diggingAreaDictionnary);
                break;
                
            
        }
        
        
        
        Debug.LogError("method is not working properly");
        return Vector3.zero;
    }


    private Vector3 closestTarget(Dictionary<Vector3[], float[]> dictionary)
    {
        //contains the distances from the dictionnary Tvalue "Dictionnary<TKey,TValue>"
        float[] distances = dictionary.Values.ElementAt(0); 
          

        Vector3 closestPosition = Vector3.zero;
        
        float temp = dictionary.Values.ElementAt(0)[0];
        
        for (int i = 0; i < distances.Length; i++)
        {
            if ( temp > dictionary.Values.ElementAt(0)[i] ) //Math.Absolute ?? for negative values??
            {
                temp = dictionary.Values.ElementAt(0)[i];
                closestPosition = dictionary.Keys.ElementAt(0)[i];


            }
            
        }
        
        DebugPosition(temp, closestPosition);

        return closestPosition;
    }

    public void DebugPosition(float printF, Vector3 printV)
    {
        //for(int i = 0; i< )
        Debug.Log(" PositionDebug : " + printF + " " + printV);
    }



 
}
