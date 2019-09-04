using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithinARadius : MonoBehaviour
{

    public Transform target;

    public float radius;
    public bool useLateUpdate;

    public bool useMinY;
    public float minY;


    // Update is called once per frame
    void Update()
    {
        if (!useLateUpdate)
        {

            NormalUpdate();
        }

    }



    private void LateUpdate()
    {
        if (useLateUpdate) {

            NormalUpdate();
        }
    }

    
    
   

    void NormalUpdate() {

        Vector3 deltaPos = gameObject.transform.position - target.position;


        if (deltaPos.magnitude > radius)
        {

            transform.position = target.position + deltaPos.normalized * radius;

        }

        if (useMinY) {

            transform.position = new Vector3(transform.position.x, Mathf.Max(minY, transform.position.y), transform.position.z);
        }


        Vector3 norm = deltaPos.normalized;
        Vector3 rad = norm * radius;






        //offset values
        Vector3 y1 = new Vector3(0, 0.1f, 0);
        Vector3 y2 = new Vector3(0, 0.2f, 0);

        //drawlines
        Debug.DrawLine(target.position, target.transform.position + deltaPos, Color.black);
        Debug.DrawLine(target.position + y1, target.transform.position + norm + y1, Color.blue);
        Debug.DrawLine(target.position + y2, target.transform.position + rad + y2, Color.red);



    }
}
