using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkSphere : MonoBehaviour
{
    public float horizontal, vertical;

    public Vector3 directionNormalize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        
        directionNormalize = new Vector3(horizontal,0, vertical).normalized;

        transform.Translate(directionNormalize);

    
    }
}
