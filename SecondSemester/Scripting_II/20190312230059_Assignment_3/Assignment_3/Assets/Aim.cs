using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform target;
    [Range(0.1f, 5.0f)]
    public float sensibility = 1.0f;

    public Transform rightShoulderAnhor;

     public void Init(Vector3 targetPos, float timer)
    {        
        transform.rotation *= Quaternion.FromToRotation(transform.forward, targetPos - transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        rightShoulderAnhor.rotation = Quaternion.FromToRotation(transform.forward, targetPos - transform.position);
        rightShoulderAnhor.eulerAngles = new Vector3(rightShoulderAnhor.eulerAngles.x, 0, rightShoulderAnhor.eulerAngles.z);
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
    }
}
