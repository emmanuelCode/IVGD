using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateWithMouseAxis
{
    x,
    y,
    z
}

public class RotateWithMouse : MonoBehaviour
{
    public float sensitivity = 1.0f;
    public bool reversed = false;
    public RotateWithMouseAxis rotateWithMouseAxis;
    public string mouseAxisName;
    // Start is called before the first frame update
    void Start()
    {
        if (mouseAxisName == "")
        {
            Debug.LogWarning("Missing Mouse Axis Name");
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float axisValue = Input.GetAxis(mouseAxisName);

        if (reversed)
            axisValue *= -1;

        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        switch(rotateWithMouseAxis)
        {
            case RotateWithMouseAxis.x:
                x = axisValue;
                break;
            case RotateWithMouseAxis.y:
                y = axisValue;
                break;
            case RotateWithMouseAxis.z:
                z = axisValue;
                break;
        }

        transform.Rotate(new Vector3(x, y, z) * sensitivity);
    }
}
