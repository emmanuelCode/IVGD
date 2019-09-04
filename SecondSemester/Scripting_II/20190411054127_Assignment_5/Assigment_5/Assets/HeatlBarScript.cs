using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlBarScript : MonoBehaviour
{

    [SerializeField]
    private Image foreground;

    [SerializeField] 
    private Health targetHealth;

    public Camera lookAtCam;

    public bool keepRelativePos;
    private Vector3 relativeOffset;
    private Transform relativeTarget;

    private Rigidbody rb;


    public GameObject healthBarCanvas, gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        relativeOffset = transform.parent.transform.localPosition;
        
        relativeTarget = transform.parent.transform.parent;//this is the cube!!
        
        transform.parent.transform.parent = null;
        rb = relativeTarget.GetComponent<Rigidbody>();
        //healthBarCanvas = GameObject.Find("HealthBarCanvas");
    }

    // Update is called once per frame
    void Update()
    {

        float healthRation = targetHealth.health / targetHealth.maxHealth;
        
        foreground.fillAmount = Mathf.Lerp(foreground.fillAmount, healthRation, 0.2f); //healthRatio

        if (keepRelativePos)
        {
            transform.parent.transform.position = relativeTarget.position + relativeOffset + new Vector3(0,10.12f,0);//needed to add this(new Vector3)

        }

        if (lookAtCam != null)
        {
            transform.LookAt(lookAtCam.transform);
        }

        if (healthRation == 0)
        {
           
            Destroy(healthBarCanvas);
            gameOverPanel.SetActive(true);
            
            
        }


        //forground.fillAmount = Mathf.Lerp(forground.fillAmount, healthRation, 0.2f);// need to ask for proper Mathf Learp for health
        
        
    }

    //couldn't make it move... :( 
    private void FixedUpdate()
    {
        //inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 desiredMovement = new Vector3(horizontal,0,vertical).normalized;
        
        
        rb.AddForce(desiredMovement,ForceMode.Force);
        
        
    }
}
