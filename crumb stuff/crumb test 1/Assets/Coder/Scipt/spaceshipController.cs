using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class spaceshipController : MonoBehaviour
{
    float vert;
    float horiz;
    float turnspeed = 150.0f;    //75
    float movespeed = 600.0f;   //300
    float maxspeed = 40.0f;     //20
    float brakespeed = 500.0f;
    float steerval;
    float accelval;
    float brakeval;
    private PlayerInput playerinput;
    private Controls playercontrols;
    public Rigidbody rigidbody;


    private void Awake()
    {
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
    }


    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        steerval = context.ReadValue<float>(); 
    }
    public void OnAccel(InputAction.CallbackContext context)
    {
        accelval = context.ReadValue<float>();
    }
    public void OnBrake(InputAction.CallbackContext context)
    {
        brakeval = context.ReadValue<float>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,turnspeed * steerval * Time.deltaTime, 0);
        rigidbody.AddForce(transform.forward * accelval * Time.deltaTime * movespeed - rigidbody.velocity * brakeval * Time.deltaTime * brakespeed);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxspeed);

    }
}