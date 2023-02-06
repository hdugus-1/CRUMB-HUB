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
    float turnspeed = 75.0f;
    float movespeed = 300.0f;
    float maxspeed = 20.0f;
    float brakespeed = 1000.0f;
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
        transform.Rotate(0,0, turnspeed * -steerval * Time.deltaTime);
        rigidbody.AddForce(transform.up * accelval * Time.deltaTime * movespeed - rigidbody.velocity * brakeval * Time.deltaTime * brakespeed);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxspeed);

    }
}