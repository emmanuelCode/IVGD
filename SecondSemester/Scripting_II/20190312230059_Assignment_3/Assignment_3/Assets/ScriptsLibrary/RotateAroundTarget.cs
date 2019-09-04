using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    public Transform target;
    [Range(0.1f, 5.0f)]
    public float sensibility = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensibility;
        float vertical = Input.GetAxis("Mouse Y") * sensibility;

        if (horizontal == 0)
            horizontal = Input.GetAxis("Right Horizontal") * sensibility;
        if (vertical == 0)
            vertical = Input.GetAxis("Right Vertical") * sensibility;
        
        transform.RotateAround(target.position, target.up, horizontal);
        transform.RotateAround(target.position, Vector3.ProjectOnPlane(Vector3.Cross((target.position - transform.position), target.transform.up), Vector3.up), vertical);
    }
}
