using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;


public class PlayerControllers : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;

    //public float leftBoundary = -10.0f;
   // public float rightBoundary = 10.0f;
   // EQUAL to public float xRange = 10.0f
    public float xRange =10.0f;

// Storing oblects
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Dont go off the screen
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Space Bar is Lauching projectile

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from player
            //make copy of object
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }
}
