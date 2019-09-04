using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : MonoBehaviour
{

    private float horizontal, vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //doesn't work with number pad...
        horizontal = Input.GetAxis("Horizontal46");
        vertical = Input.GetAxis("Vertical58");

        Vector3 normalizedDirection = new Vector3(horizontal,0,vertical).normalized;


        transform.Translate(normalizedDirection * Time.deltaTime);
        
    }
}
