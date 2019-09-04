using UnityEngine;
using System.Collections;


public class LookAt : MonoBehaviour
{
	//The target to look at
    public Transform target;

	//This represent the speed at wich the camera  will slerp toward desired look at orientation
	public float dampingSpeed = 0;
	//This tells if we want to use smooth movement or not
	public bool useDamping = false;
	//This tells if we want to adjust to the target up vector or not
	public bool useTargetUp = false;
	//This tells if we want to  use LateUpdate or Update. (For a camera, we should use LateUpdate)
	public bool useLateUpdate = false;

    void Update ()    
	{   
		//If user wants to use LateUpdate, we simply exit
		if(useLateUpdate)
			return;

		//Otherwise, we call the actual LookAtUpdate function
		LookAtUpdate();
	}
	void LateUpdate()
	{
		//If user doesn't want to use LateUpdate, we simply exit
		if(!useLateUpdate)
			return;

		//Otherwise, we call the actual LookAtUpdate function
		LookAtUpdate();
	}

	void LookAtUpdate()
	{
		//Here is where the rotation is set
		//We itinialise the wantedUp to the world up
		Vector3 wantedUp = Vector3.up;
		//Then we check if we have to adjust to target up vector
		if(useTargetUp)
			//If yes we set wantedUp to the target up vector
			wantedUp = target.up;

		//Then we create the final wanted Rotation as wantedLookAt
		Quaternion wantedLookAt = Quaternion.LookRotation((target.position - transform.position).normalized, wantedUp);
		//Now we have to adjust our rotation to reach wantedLookAt
		//Either we have to use Damping
		if(useDamping)
		{
			//So we smootly slerp our way toward wantedLookAt
			transform.rotation = Quaternion.Slerp(transform.rotation, wantedLookAt, dampingSpeed * Time.deltaTime);
		}
		else
		{
			//If we don't use damping, we then set our rotation rigth away to wantedLookAt
			transform.rotation = wantedLookAt;
		}
	}

}