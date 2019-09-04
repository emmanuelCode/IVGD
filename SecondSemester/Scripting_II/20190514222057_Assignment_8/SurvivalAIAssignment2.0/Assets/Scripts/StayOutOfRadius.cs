using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOutOfRadius: MonoBehaviour 
{
	//Contain the actual limit proximity that we can get from target anchor
	public float forbidenRadius = 10.0f;
	//The actual transform from wich we need to stay forbidenRadius away
	public Transform anchor;

	//This will contain the rigidBody of the gameObject if there is one
	Rigidbody rigidBody = null;

    public bool usingLateUpdate = false;

    void Start()
	{        
		//This means that LookForRigidBody will be automaticaly called at every 1 second starting in 0 second
		InvokeRepeating("LookForRigidBody", 0, 1);   
	}  

	void LookForRigidBody()
	{        
		//This function check if gameObject contains a rigidBody
		rigidBody = GetComponent<Rigidbody>();
		if (rigidBody)
			//If one rigidBody is found, this fucntion as no reason for being recalled, so we cancel the automatic invoke system.
			CancelInvoke("LookForRigidBody");
	}

    void Update()
    {
        if (rigidBody || usingLateUpdate)
            return;

        StayOutOfRatiusUpdate();
    }

    void LateUpdate()
    {
        if (rigidBody || !usingLateUpdate)
            return;

        StayOutOfRatiusUpdate();
    }

    void FixedUpdate()
    {
        if (!rigidBody)
            return;
        //We are in Fixed update because we manipulate physic element
        StayOutOfRatiusUpdate();
    }

    void StayOutOfRatiusUpdate()
	{		
		//Get the diference position between gameObject position and the anchor one
		Vector3 deltaPos = transform.position - anchor.position;

		//Check if the distance is smaller then the minimum required
		if (deltaPos.sqrMagnitude < Mathf.Pow(forbidenRadius, 2))
		{
			//Yes it's too close, so we have to push it away.
			if (rigidBody)
			{
				//If there is a rigidBody, we must cancel any velocity going inside the forbiden sphere
				rigidBody.AddForce(-deltaPos.normalized * Vector3.Dot(GetComponent<Rigidbody>().velocity, deltaPos));
			}

			//Then we move the position at the edge of the forbiden sphere
			transform.position = anchor.transform.position + deltaPos.normalized * forbidenRadius;
		}
	}
}

