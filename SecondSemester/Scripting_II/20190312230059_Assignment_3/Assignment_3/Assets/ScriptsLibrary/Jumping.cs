using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumping : MonoBehaviour
{    
    
    public KeyCode jumpKey;
    public float jumpPower;
    public float doubleJumpPower;
    public float fallingGravityMultiplyer = 1.0f;
    public float jumpCancelingGravityMultipliyer = 1.0f;
    public float jumpUpwardGravityModifyer = 1.0f;
    public int nbDoubleJump = 0;

    Rigidbody rigidBody;    
    int doubleJumpCount;
    bool isJumping;
    bool isInInitialJumping;
    GroundSensor groundSensor;
    public float jumpVelcityEpsilon = Mathf.Epsilon;
    [Range(0, float.MaxValue)]
    public float maxFallingSpeed = float.MaxValue;
    
    private bool IsJumping
    {
        get { return isJumping; }
        set { isJumping = value; doubleJumpCount = 0; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        IsJumping = false;
        doubleJumpCount = 0;
        groundSensor = gameObject.GetComponentInChildren<GroundSensor>();
        if (!groundSensor)
        {
            Debug.LogWarning("Jumping Script not paired with a GroundSensor... Ground detection will be replaced by velocity analysis and will be less responsive... SetOnGround can be call to improve responsiveness");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsJumping && isInInitialJumping && Vector3.Dot(rigidBody.velocity, Physics.gravity) > 0)
            isInInitialJumping = false;

        if(!groundSensor && !isInInitialJumping)
        {
            if (Mathf.Abs(Vector3.Dot(rigidBody.velocity, Physics.gravity.normalized)) < jumpVelcityEpsilon)
                SetOnGround();
        }
                
        if (Input.GetKeyDown(jumpKey) && !Jump())
        {           
            DoubleJump();         
        }        
    }

    private void FixedUpdate()
    {
        if (!rigidBody)
            return;

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.AddForce(Physics.gravity * (fallingGravityMultiplyer - 1), ForceMode.Acceleration);
            if (rigidBody.velocity.y < -maxFallingSpeed * Time.fixedDeltaTime)
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, -maxFallingSpeed * Time.fixedDeltaTime, rigidBody.velocity.z);
                rigidBody.AddForce(-Physics.gravity, ForceMode.Acceleration);
            }
            else if(Input.GetKey(KeyCode.V))
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, -maxFallingSpeed * Time.fixedDeltaTime, rigidBody.velocity.z);
                rigidBody.AddForce(-Physics.gravity, ForceMode.Acceleration);
            }
        }
        else
        {
            if (!Input.GetKey(KeyCode.Space))
                rigidBody.AddForce(Physics.gravity * (jumpCancelingGravityMultipliyer - 1));
            else
                rigidBody.AddForce(Physics.gravity * (jumpUpwardGravityModifyer - 1));
        }
    }

    bool Jump()
    {
        if (!IsJumpAllowed())
            return false;

        rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        IsJumping = true;
        isInInitialJumping = true;
        return true;
    }

    void DoubleJump()
    {
        if (!IsDoubleJumpAllowed())
            return;

        if (doubleJumpCount++ < nbDoubleJump)
        {     
            rigidBody.velocity = rigidBody.velocity - Vector3.Project(rigidBody.velocity, Physics.gravity.normalized);
            rigidBody.AddForce(Vector3.up * doubleJumpPower, ForceMode.Impulse);
        }
    }

    public bool IsJumpAllowed()
    {    
        return (!IsJumping);
    }

    public bool IsDoubleJumpAllowed()
    {
        return (IsJumping && (nbDoubleJump - doubleJumpCount) > 0);
    }

    public void SetOnGround()
    {
        isJumping = false;
        doubleJumpCount = 0;
    }

    void OnGroundSensorDetection()
    {
        SetOnGround();        
    }
}