using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachTargetInTimeSpawner : MonoBehaviour
{
    public Transform target;
    public bool attachToTargetWhenReached;
    public float reachingTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReachTargetInTime reachTargetInTime = gameObject.AddComponent<ReachTargetInTime>();
            reachTargetInTime.SetInitialValue(target, reachingTime, attachToTargetWhenReached);
        }
    }
}
