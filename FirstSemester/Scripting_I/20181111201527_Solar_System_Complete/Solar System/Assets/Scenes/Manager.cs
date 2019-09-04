using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Manager : MonoBehaviour
{

	public Dictionary<string, float> planetsInfo;
	public Sun sun;
	//public Moon moon;
	public float speed;

	public Vector3 sunPositon;

	

	// Use this for initialization
	void Start ()
	{
		sunPositon = sun.transform.position;
		
		


		planetsInfo = new Dictionary<string, float>();
		planetsInfo.Add("mercury", speed + 1);
		planetsInfo.Add("venus", speed + 2);
		planetsInfo.Add("earth", speed + 3);
		planetsInfo.Add("mars", speed + 4);
		planetsInfo.Add("jupiter",speed + 5);
		planetsInfo.Add("saturn", speed + 6);
		planetsInfo.Add("uranus",speed + 7);
		planetsInfo.Add("neptune",speed + 8);
		planetsInfo.Add("pluto", speed + 9);
		
		

	}
	
	// Update is called once per frame
	void Update ()
	{

		planetsInfo["mercury"] = speed + 1;
		planetsInfo["venus" ] = speed + 2;
		planetsInfo["earth" ] = speed + 3;
		planetsInfo["mars"] = speed + 4;  
		planetsInfo["jupiter"]= speed + 5;
		planetsInfo["saturn"] = speed + 6;
		planetsInfo["uranus"] = speed + 7;
		planetsInfo["neptune"] = speed + 8;
		planetsInfo["pluto" ]= speed + 9; 


	}
}
