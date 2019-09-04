using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{

    public Transform target;

    public bool useDamping;
    public float damping;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!useDamping)
        {
           transform.position = target.transform.position;




        }
        else {

            transform.position = Vector3.Lerp(gameObject.transform.position, target.position, damping * Time.deltaTime);
        }

    }
}
