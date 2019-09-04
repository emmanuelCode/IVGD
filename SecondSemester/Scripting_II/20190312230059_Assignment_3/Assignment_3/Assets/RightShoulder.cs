using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightShoulder : MonoBehaviour
{
/*    public Camera mainCamera;
    public Transform targetAiming;
    public Transform targetRest;
    public Transform cameraAimingAnchor;
    public Transform camera3rdAnchor;
    public GameObject initialAim;
    public GameObject character;

    public float rotationSpeed;    
    Transform target;
    public Gun gun;

    private void Start()
    {
        if (!mainCamera)
            mainCamera = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && target != targetAiming)
        {
            SetTarget(targetAiming);
            CameraReachAimingPos(0.2f);
            initialAim.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10;
            character.GetComponent<LookForward>().Activate(false);
            character.GetComponent<Aim>().Init(mainCamera.transform.position + mainCamera.transform.forward * 10, 0.2f);

        }
        else if (!Input.GetMouseButton(1) && target != targetRest)
        {
            gun.SafetyPinEngaged = true;
            SetTarget(targetRest);
            CameraBackTo3rdAnchor(0.2f);
            character.GetComponent<LookForward>().Activate(true);
            character.GetComponent<Aim>().enabled = false;
        }
    }

    void SetTarget(Transform pTarget)
    {
        DestroyAllReachingScript(gameObject);
        target = pTarget;
        ReachTargetConstantSpeed reachTargetConstantSpeed = gameObject.AddComponent<ReachTargetConstantSpeed>();
        reachTargetConstantSpeed.SetInitialValue(target, 0, rotationSpeed, false);
    }

    void DestroyAllReachingScript(GameObject pGameObject)
    {
        ReachTargetConstantSpeed[] reachTargetConstantSpeedArray = pGameObject.GetComponents<ReachTargetConstantSpeed>();
        for (int i = 0; i < reachTargetConstantSpeedArray.Length; ++i)
        {
            Destroy(reachTargetConstantSpeedArray[i]);
        }        
    }

    void CameraReachAimingPos(float timer)
    {
        Activate3rdPersonScript(false);
        DestroyAllReachingScript(mainCamera.gameObject);
        ReachTargetInTime reachTargetInTime = mainCamera.gameObject.AddComponent<ReachTargetInTime>();
        reachTargetInTime.SetInitialValue(cameraAimingAnchor, timer, true);
        
    }

    void CameraBackTo3rdAnchor(float timer)
    {
        mainCamera.transform.parent = null;
        Activate3rdPersonScript(false);
        DestroyAllReachingScript(mainCamera.gameObject);
        ReachTargetInTime reachTargetInTime = mainCamera.gameObject.AddComponent<ReachTargetInTime>();
        reachTargetInTime.SetInitialValue(camera3rdAnchor, timer, false);
        Invoke("Activate3rdPersonScript", timer);
    }

    void Activate3rdPersonScript()
    {
        Activate3rdPersonScript(true);
    }

    void Activate3rdPersonScript(bool pValue)
    {
        if (mainCamera.GetComponent<LookAt>())
            mainCamera.GetComponent<LookAt>().enabled = pValue;
        if (mainCamera.GetComponent<StayWithinARadius>())
            mainCamera.GetComponent<StayWithinARadius>().enabled = pValue;
        if (mainCamera.GetComponent<StayOutOfRadius>())
            mainCamera.GetComponent<StayOutOfRadius>().enabled = pValue;
        if (mainCamera.GetComponent<FollowTarget>())
            mainCamera.GetComponent<FollowTarget>().enabled = pValue;
        if (mainCamera.GetComponent<Toggle_1_3_person_camera>())
            mainCamera.GetComponent<Toggle_1_3_person_camera>().enabled = pValue;
        if (mainCamera.GetComponent<RotateAroundTarget>())
            mainCamera.GetComponent<RotateAroundTarget>().enabled = pValue;
    }

    void OnReachTargetConstantSpeedDone()
    {
        if (target == targetAiming)
        {
            gun.SafetyPinEngaged = false;
        }        
    }*/
}
