using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    public float speed = 2;
    public float height = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveObject();
    }
    
    
    void moveObject()
    {
        Vector3 pos = transform.position;
        
        float newY = Mathf.Sin(Time.time*speed);
        
        transform.position += new Vector3(newY,0 , 0) * height;

    }
}
