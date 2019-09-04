using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eUpdateMode
{
    automatic,
    manual
}

public class LookForward : MonoBehaviour
{
    Vector3 lastPos;

    public bool useDamping;
    public float damping;

    Rigidbody rigidBody;

    public string[] axiesFilter;

    bool active;
    public float minDeltaPos;

    public eUpdateMode updateMode;    

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Init();       
    }

    public void Activate(bool value)
    {
        active = value;
    }

    private void Init()
    {
        active = true;
        if (rigidBody)
        {
            lastPos = rigidBody.transform.position;
        }
        else
        {
            lastPos = transform.position;
        }
    }    

    // Update is called once per frame
    void Update()
    {
        if (!active || updateMode != eUpdateMode.automatic)
            return;

        if(axiesFilter != null && axiesFilter.Length > 0)
        {
            bool accessGranted = false;            
            for (int i = 0; i < axiesFilter.Length; ++i)
            {                
                if (Input.GetAxisRaw(axiesFilter[i]) != 0)
                {
                    accessGranted = true;
                    break;
                }
            }
            if (!accessGranted)
            {
                return;
            }
        }

        if ((transform.position - lastPos).sqrMagnitude > Mathf.Pow(minDeltaPos, 2))
        {
            if (rigidBody)
            {
                Quaternion wantedRotation = Quaternion.LookRotation((rigidBody.position - lastPos).normalized, Vector3.up);
                if (!useDamping)
                {
                    rigidBody.rotation = wantedRotation;
                }
                else
                {
                    rigidBody.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, damping * Time.deltaTime);
                }
            }
            else
            {
                Quaternion wantedRotation = Quaternion.LookRotation((transform.position - lastPos).normalized, Vector3.up);
                if (!useDamping)
                {
                    transform.rotation = wantedRotation;
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, damping * Time.deltaTime);
                }
            }

            lastPos = transform.position;
        }        
    }

    public void Update(Vector3 lookForwardTarget)
    {
        if (!enabled)
            return;

        if (lookForwardTarget != Vector3.zero)
        {
            if (rigidBody)
            {
                Quaternion wantedRotation = Quaternion.LookRotation(lookForwardTarget.normalized, Vector3.up);
                if (!useDamping)
                {
                    rigidBody.rotation = wantedRotation;
                }
                else
                {
                    rigidBody.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, damping * Time.deltaTime);
                }
            }
            else
            {
                Quaternion wantedRotation = Quaternion.LookRotation(lookForwardTarget.normalized, Vector3.up);
                if (!useDamping)
                {
                    transform.rotation = wantedRotation;
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, damping * Time.deltaTime);
                }
            }
        }
    }

    void UpdateRigidbody()
    {
        if (!rigidBody)
            return;       

        lastPos = rigidBody.position;
    }
}
