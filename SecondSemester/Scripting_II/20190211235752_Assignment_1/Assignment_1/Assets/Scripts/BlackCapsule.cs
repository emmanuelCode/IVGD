using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCapsule : MonoBehaviour
{

    private Rigidbody rb;

    
    private float horizontal, vertical;

    public float accelForce = 1f;

    public Vector3 normalizeDirection;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("HorizontalJL");
        vertical = Input.GetAxis("VerticalKI");

        normalizeDirection = new Vector3(horizontal, 0, vertical).normalized;
       
    }

    void FixedUpdate(){

        rb.AddForce(normalizeDirection * accelForce, ForceMode.Acceleration);

    }
}
