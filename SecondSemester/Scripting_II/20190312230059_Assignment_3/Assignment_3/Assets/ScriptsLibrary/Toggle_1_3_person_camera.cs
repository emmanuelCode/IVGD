using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_1_3_person_camera : MonoBehaviour
{
    bool is3rdPerson;
    public Transform firstPersonAnchor;
    public Transform thirdPersonAnchor;

    // Start is called before the first frame update    
    void Awake()
    {
        is3rdPerson = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is3rdPerson && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ReachTargetInTime reachTargetInTime = gameObject.AddComponent<ReachTargetInTime>();
            reachTargetInTime.SetInitialValue(firstPersonAnchor, 0.8f, true);
            Activate3rdPersonScript(false);
            is3rdPerson = false;
        }
        else if (!is3rdPerson && Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.parent = null;
            if (GetComponent<ReachTargetInTime>())
                Destroy(GetComponent<ReachTargetInTime>());

            ReachTargetInTime reachTargetInTime = gameObject.AddComponent<ReachTargetInTime>();
            reachTargetInTime.SetInitialValue(thirdPersonAnchor, 0.8f, false);
            Invoke("Activate3rdPersonScript", 0.8f);
            is3rdPerson = true;
        }
    }

    void Activate3rdPersonScript()
    {
        Activate3rdPersonScript(true);
    }

    void Activate3rdPersonScript(bool pValue)
    {
        if (GetComponent<LookAt>())
            GetComponent<LookAt>().enabled = pValue;
        if (GetComponent<StayWithinARadius>())
            GetComponent<StayWithinARadius>().enabled = pValue;
        /*NEW*/if (GetComponent<StayOutOfRadius>())
        /*NEW*/    GetComponent<StayOutOfRadius>().enabled = pValue;
        if (GetComponent<FollowTarget>())
            GetComponent<FollowTarget>().enabled = pValue;
    }
}
