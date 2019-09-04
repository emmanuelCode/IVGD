using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : MonoBehaviour
{

    public float horizontal, vertical;

    public float speed = 1f;

    public Vector3 direction, normalizeDirection, desiredDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        //assignment 
        //normalize to no need for it but will add it 
        //need to add force to directionnal keys
    {
        // for moving the cube smoothly
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0, vertical);

        normalizeDirection = direction.normalized;

        Vector3 desiredMovement = normalizeDirection * speed * Time.deltaTime;


        transform.Translate(desiredMovement);

        
    }
}
