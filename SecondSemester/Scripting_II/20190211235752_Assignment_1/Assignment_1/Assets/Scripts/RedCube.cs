using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public float normalize;

    public Vector3 direction;

    public float horizontal, vertical;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // for moving the cube less smoothy
        horizontal = Input.GetAxisRaw("HorizontalAD");
        vertical = Input.GetAxisRaw("VerticalSW");


        direction = new Vector3(horizontal, 0, vertical).normalized;

        transform.Translate(direction * speed * Time.deltaTime);




    }
}
