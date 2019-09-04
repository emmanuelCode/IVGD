using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//smooth follow pose
public class LearpDemo : MonoBehaviour
{

    public Transform initTransform;
    public Transform targetTransform;

    public float travelTime;

    float initTime;

    [Range(-1, 1)]
    public float ratio;

    public float damping;

    bool isTracking;

    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
        isTracking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            isTracking = true;
        }

        if (!isTracking)
            return;

        //Vector3 deltaPos = targetTransform.position - initTransform.position;

        float deltaTime = Time.time - initTime;

        //ratio = deltaTime / travelTime;

        //ratio = Mathf.Min(1.0f, deltaTime / travelTime);


       // if (ratio > 1) {
      //      ratio = 0;
      //  }

        // gameObject.transform.position = initTransform.position + deltaPos * ratio;

        //learp between negative values
        gameObject.transform.position = Vector3.LerpUnclamped(initTransform.position, targetTransform.position, ratio);
//        gameObject.transform.position = Vector3.Lerp(initTransform.position, targetTransform.position, ratio);


        //spherical interpolation from point a to b 
        // gameObject.transform.position = Vector3.Slerp(initTransform.position, targetTransform.position, ratio);


        //
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetTransform.position, damping * Time.deltaTime);
    }
}
