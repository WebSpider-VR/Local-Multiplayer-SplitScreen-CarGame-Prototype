using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
// Since the compiler is unable to distinguish between two different Input classes:
//1. UnityEngine.Input
//2. UnityEngine.Windows.Input
//We have to use "using UnityInput = UnityEngine.Input;"
using UnityInput = UnityEngine.Input;

public class PlayerController : MonoBehaviour

{
    //Private veriables
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    //This determins which player is using the script
    public string inputID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //This is whare we get player input
        //horizontalInput = Input.GetAxis("Horizontal");
        //forwardInput = Input.GetAxis("Vertical");

        // Moves the Vehicle forward based on verticle input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        //Below code is working fine if we are not modifing default unity key bindings

        //horizontalInput = Input.GetAxis("Horizontal" + inputID);
        //forwardInput = Input.GetAxis("Vertical" + inputID);

        // We have edited default unity input key bindings for split screen, we have to use "UnityEngine.Input" to get input axis

        //horizontalInput = UnityEngine.Input.GetAxis("Horizontal" + inputID);
        //forwardInput = UnityEngine.Input.GetAxis("Vertical" + inputID);

        // Since we have added "using UnityInput = UnityEngine.Input;" line above we can use shortcut "UnityInput"

        horizontalInput = UnityInput.GetAxis("Horizontal" + inputID);
        forwardInput = UnityInput.GetAxis("Vertical" + inputID);


        if (UnityEngine.Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
