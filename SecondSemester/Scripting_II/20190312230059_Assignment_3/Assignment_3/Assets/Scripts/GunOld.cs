using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunOld : MonoBehaviour
{
    public Camera currentCamera;
    public Transform spawnPoint;
    public float firePower;
    public GameObject bulletType;
    public float rayLength;

    public Image aimCross;

    bool safetyPinEngaged = true;
    public bool SafetyPinEngaged
    {
        get { return safetyPinEngaged; }
        set { safetyPinEngaged = value; aimCross.enabled = !value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!currentCamera)
        {
            currentCamera = Camera.main;
        }

       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SafetyPinEngaged)
            return;

        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 aimPos = currentCamera.transform.position + ray.direction * rayLength;

        Vector3 aimPos2 = Vector3.ProjectOnPlane(aimPos, spawnPoint.transform.up);
        Debug.DrawLine(transform.position, aimPos2, Color.green);

        Debug.DrawLine(currentCamera.transform.position, aimPos);
        Debug.DrawLine(spawnPoint.transform.position, aimPos, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletType);
            newBullet.transform.position = spawnPoint.transform.position;
            newBullet.GetComponent<Rigidbody>().AddForce(aimPos2.normalized * firePower, ForceMode.Impulse);

            newBullet = Instantiate(bulletType);
            newBullet.transform.position = spawnPoint.transform.position;
            newBullet.GetComponent<Rigidbody>().AddForce(aimPos.normalized * firePower, ForceMode.Impulse);

        }
    }
}
