using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScene1GameEngine : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject character;
    public Transform characterShoulder;
    public Transform aimingCameraAnchor;
    bool characterIsAiming;
    public Gun gun;
    public Image aim;

    public Vector3 lastFreeCamPosition;
    public Vector3 lastFreeCamRelativePosition;
    public Quaternion lastFreeCamRotation;
    public Vector3 lastFreeCamLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        GrabAndHideCursor();
        characterIsAiming = false;
    }

    void GrabAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            GrabAndHideCursor();
        bool isDebug = Input.GetKey(KeyCode.LeftShift);

        if(!characterIsAiming && (isDebug || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            character.transform.rotation = Quaternion.identity;

            Vector3 aimingTarget = mainCamera.transform.position + mainCamera.transform.forward * 25;
            Vector3 noYAimingTarget = new Vector3(aimingTarget.x, characterShoulder.position.y, aimingTarget.z);
            
            Vector3 shoulderTarget = characterShoulder.position + ((character.transform.forward * noYAimingTarget.magnitude) + (Vector3.up * aimingTarget.y));

            Debug.DrawLine(character.transform.position, aimingTarget);
            Debug.DrawLine(character.transform.position, noYAimingTarget, Color.blue);            
            Debug.DrawLine(characterShoulder.position, shoulderTarget, Color.black);

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Quaternion characterWantedRotation = Quaternion.FromToRotation(character.transform.forward, (noYAimingTarget - characterShoulder.transform.position).normalized);
                Quaternion shoulderWantedRotation = Quaternion.FromToRotation(characterShoulder.forward, (shoulderTarget - characterShoulder.transform.position).normalized);

                character.transform.rotation *= characterWantedRotation;
                characterShoulder.transform.localRotation *= shoulderWantedRotation;

                characterIsAiming = true;
                Activate3rdPersonScript(false);

                lastFreeCamPosition = mainCamera.transform.localPosition;
                // lastFreeCamRelativePosition = mainCamera.transform.localPosition - chara
                lastFreeCamRotation = mainCamera.transform.localRotation;
                lastFreeCamLocalScale = mainCamera.transform.localScale;

                mainCamera.transform.parent = aimingCameraAnchor;
                mainCamera.transform.localPosition = Vector3.zero;
                mainCamera.transform.localRotation = Quaternion.identity;
                mainCamera.transform.localScale = Vector3.one;

                gun.safetyPin = false;
                characterShoulder.GetComponent<RotateWithMouse>().enabled = true;
                character.GetComponent<RotateWithMouse>().enabled = true;
                character.GetComponent<LookForward>().enabled = false;
                aim.enabled = true;                
            }
        }
        else if(characterIsAiming && !Input.GetKey(KeyCode.Mouse1))
        {            
            gun.safetyPin = true;
            characterIsAiming = false;
            Activate3rdPersonScript();
            mainCamera.transform.parent = null;            
            characterShoulder.GetComponent<RotateWithMouse>().enabled = false;
            character.GetComponent<RotateWithMouse>().enabled = false;
            character.GetComponent<LookForward>().enabled = true;
            aim.enabled = false;
            characterShoulder.transform.localRotation = Quaternion.Euler(90, 0, 0);

            mainCamera.transform.localPosition = lastFreeCamPosition;
            mainCamera.transform.localRotation = lastFreeCamRotation;
            mainCamera.transform.localScale = lastFreeCamLocalScale;
        }
    }

    void Activate3rdPersonScript()
    {
        Activate3rdPersonScript(true);
    }

    void Activate3rdPersonScript(bool pValue)
    {
        if (mainCamera.GetComponent<LookAt>())
            mainCamera.GetComponent<LookAt>().enabled = pValue;
        if (mainCamera.GetComponent<StayWithinBox>())
            mainCamera.GetComponent<StayWithinBox>().enabled = pValue;
        if (mainCamera.GetComponent<StayWithinARadius>())
            mainCamera.GetComponent<StayWithinARadius>().enabled = pValue;
        if (mainCamera.GetComponent<StayOutOfRadius>())
            mainCamera.GetComponent<StayOutOfRadius>().enabled = pValue;        
        if (mainCamera.GetComponent<RotateAroundTarget>())
            mainCamera.GetComponent<RotateAroundTarget>().enabled = pValue;
    }
}
