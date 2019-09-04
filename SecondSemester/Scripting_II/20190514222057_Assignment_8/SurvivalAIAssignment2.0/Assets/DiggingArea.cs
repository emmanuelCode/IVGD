using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingArea : MonoBehaviour
{

    bool digged;
    GameObject character;
    public GameObject treasure;

	// Use this for initialization
	void Start ()
    {
        digged = false;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(digged)
        {
            if(Vector3.Distance(transform.position, character.transform.position) >= 1.5f)
            {
                GameObject.Instantiate(treasure, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
                GameObject.Find("GameEngine").GetComponent<GameEngine>().SetAchievementScore("7 - Successfuly Dig Up Healthpack 1pt", 1);
                Destroy(gameObject);                
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
		character = other.gameObject.transform.parent.gameObject;
        if (character.GetComponent<Character>().HasShovel())
        {
            digged = true;
            character.GetComponent<Character>().ConsumeShovel();
        }
    }
}
