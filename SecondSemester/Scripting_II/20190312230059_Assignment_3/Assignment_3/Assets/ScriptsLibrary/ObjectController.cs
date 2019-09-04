using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{       
    public Transform pointOfView;

    public Vector3 groundNormal = Vector3.up;

    Vector3 desiredDirection;

    Rigidbody rigidBody;
    public float speed = 5.0f;    
    
    public LookForward lookForward;

    public bool useRawAxis = false;
    public string horizontalAxisName = "Horizontal";
    public string verticalAxisName = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    
        lookForward = gameObject.GetComponent<LookForward>();
        if (lookForward)
            lookForward.updateMode = eUpdateMode.manual;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal;
        float vertical;
        if (useRawAxis)
        {
            horizontal = Input.GetAxisRaw(horizontalAxisName);
            vertical = Input.GetAxisRaw(verticalAxisName);
        }
        else
        {
            horizontal = Input.GetAxis(horizontalAxisName);
            vertical = Input.GetAxis(verticalAxisName);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.Translate(Vector3.down);
                
        if (pointOfView && pointOfView != transform)
        {
            Vector3 forward = Vector3.ProjectOnPlane(pointOfView.forward, groundNormal);            
            Vector3 right = Vector3.Cross(groundNormal, forward);

            desiredDirection = right * horizontal + forward * vertical;
        }        
        else
        {
            desiredDirection = new Vector3(horizontal, 0, vertical);
        }

        if(groundNormal != Vector3.zero)
        {
            desiredDirection = Vector3.ProjectOnPlane(desiredDirection, groundNormal);
        }
                
        if (desiredDirection.sqrMagnitude > 1)
            desiredDirection = desiredDirection.normalized;        
        
        if(!rigidBody)
        {
            Vector3 desireMovement = desiredDirection * speed * Time.deltaTime;
            transform.Translate(desireMovement, Space.World);
        }        

        if (lookForward && (Input.GetAxisRaw(horizontalAxisName) != 0 || Input.GetAxisRaw(verticalAxisName) != 0))
            lookForward.Update(desiredDirection);
    }

    private void FixedUpdate()
    {
        if (!rigidBody)
            return;
        
        //rigidbody.AddForce(desiredDirection * accelForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        rigidBody.AddForce(desiredDirection * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);                
    }   
}