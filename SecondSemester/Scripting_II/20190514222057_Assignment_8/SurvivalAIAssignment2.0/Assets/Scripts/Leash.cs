using UnityEngine;
using System.Collections;

public class Leash : MonoBehaviour
{
	//The actual GameObject from wich we need to stay closer than maxLength
    public GameObject anchor;
	//The maximum length from the anchor that we can be
    public float maxLength;

	//This tells if we need to respect a minimum value for our y position
	public bool useMinimumY = false;
	//This is the minimum y position to respect if useMinimumY is true
	public float minimumY;

	//This tells if we need to respect a maximum value for our y position
	public bool useMaximumY = false;
	//This is the maximum y position to respect if useMaximumY is true
	public float maximumY;

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

        LeashUpdate();
    }

    void LateUpdate()
    {
        if (rigidBody || !usingLateUpdate)
            return;

        LeashUpdate();
    }

    void FixedUpdate()
    {
        if (!rigidBody)
            return;

        LeashUpdate();
    }

    void LeashUpdate()
    {   //We are in Fixed update because we manipulate physic element
		if(useMinimumY)
		{
			if(transform.position.y<minimumY)
			{
				Vector3 wantedPos = new Vector3(transform.position.x, minimumY, transform.position.z);
                Vector3 yDeltaPos = transform.position - wantedPos;

				if (rigidBody)
				{
					rigidBody.AddForce(-yDeltaPos.normalized* Vector3.Dot(GetComponent<Rigidbody>().velocity, yDeltaPos));                
				}

                transform.position = wantedPos;			
			}
		}

		if(useMaximumY)
		{
			if(transform.position.y > maximumY)
			{
				Vector3 wantedPos = new Vector3(transform.position.x, maximumY, transform.position.z);
                Vector3 yDeltaPos = transform.position - wantedPos;

				if (rigidBody)
				{
					rigidBody.AddForce(-yDeltaPos.normalized* Vector3.Dot(GetComponent<Rigidbody>().velocity, yDeltaPos));                
				}

				transform.position = wantedPos;			
			}
		}

		//Get the diference position between gameObject position and the anchor one
        Vector3 deltaPos = transform.position - anchor.transform.position;
		//Check if the distance is greather then the maximum allowed
        if (deltaPos.sqrMagnitude > Mathf.Pow(maxLength, 2))
        {
			//Yes it's too far, so we have to pull it closer.
            if (rigidBody)
            {
				//If there is a rigidBody, we must cancel any velocity going outside the limit sphere
                rigidBody.AddForce(-deltaPos.normalized* Vector3.Dot(GetComponent<Rigidbody>().velocity, deltaPos));                
			}
			//Then we move the position at the edge of the limit sphere
			transform.position = anchor.transform.position + deltaPos.normalized* maxLength;		          
        }
    }
		
}
