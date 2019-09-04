using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	//Storing initial and end time
	float initTime;
	float endTime;

	//If ration is requested, we compute it and return it
	public float Ratio
	{
		get
		{			
			return Mathf.Min((Time.time - initTime) / (endTime - initTime), 1.0f);
		}
	}

	//Constructor without parameter
	public Timer(){}
	//Constructor with a time parameter
	public Timer(float time)
	{
		Set(time);
	}

	public void Set(float time)
	{
		//The set funciton initialise initial and  end time;
		initTime = Time.time;
		endTime = initTime + time;
	}


}

