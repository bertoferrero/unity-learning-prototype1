using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public string horizontalInputName = "Horizontal";
    public string verticalInputName = "Vertical";

    private float speed = 25.0f;
    private float turnSpeed = 50.0f;

    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Collect the player input
        horizontalInput = Input.GetAxis(horizontalInputName);
        forwardInput = Input.GetAxis(verticalInputName);

        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Turn the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * forwardInput);
    }
}
