using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldOne : MonoBehaviour
{

    public Text textFieldOne; 
        
    // Start is called before the first frame update
    void Start()
    { 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetEnhancedText(string value)
    {
        textFieldOne.text = value;

    }
    
    
}
