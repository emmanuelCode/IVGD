using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    private Character character;


    private Radar r;
    private float healthRatio;

    void Awake()
    {
        character = GetComponent<Character>();
        r = new Radar(character);


    }

    // Use this for initialization
    void Start ()
    {
       

        //Example how to move character...
        //character.GotoPos(new Vector3(3, 0, 3));
        character.GotoPos(r.getToTheNearest(Radar.SHOVEL)); //starting point

        //Example how to get all scene object with a tag in one array of GameObject
        //Tag could be ("Coin", "DiggingArea", "Shovel", "HealthPack")
        //GameObject[] allObjectTaggedCoin = GameObject.FindGameObjectsWithTag("Coin");

        //Example how to know the actual ratio of health the character has
        //float healthRatio = character.GetComponent<Health>().GetHealthRatio();
        //healthRatio = character.GetComponent<Health>().GetHealthRatio();//0-100..
    }

    
    // Update is called once per frame
    void Update ()
    {
        healthRatio = character.GetComponent<Health>().GetHealthRatio();//always need the updated health
        print("HP: " + healthRatio);

        if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 4f;
        }

    }

    // This function is called by the character when destination is reached.
    void OnDestinationReached()
    {
        print("DestinationReach");
        MagicFormula();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    void MagicFormula()
    {
        
        r.Scan();

        if (character.HasShovel())
        {
            character.GotoPos(r.getToTheNearest(Radar.DIGGING_AREA));


        }
        else if(healthRatio < 0.49f )
        {
            //character.SetPause(true);
            character.GotoPos(r.getToTheNearest(Radar.HEALTH_PACK));
            
        }
        else 
        {
            character.SetPause(true);
            character.GotoPos(r.getToTheNearest(Radar.COIN));

        }
       
      
         

        print("POSITION " + character.transform.position);

    }
}
