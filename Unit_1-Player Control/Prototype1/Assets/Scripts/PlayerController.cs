using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private Variable
    private float speed = 20f;
    private float turnSpeed=23.0f;

    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    
    // Update is called once per frame

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput    = Input.GetAxis("Vertical");
        //Move the vehicle forward 
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // We turn the vehicle
        transform.Rotate(Vector3.up *Time.deltaTime * turnSpeed  * horizontalInput  );
       // Rotates the car base on horizontal input
        
       // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
        
    }
}
