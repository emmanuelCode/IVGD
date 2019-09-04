using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSceneGameEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GrabAndHideCursor();
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
    }
}
