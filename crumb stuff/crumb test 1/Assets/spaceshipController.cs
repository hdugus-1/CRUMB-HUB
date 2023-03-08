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

    public int Health = 1;

    private PlayerInput playerinput;
    private Controls playercontrols;
    public Rigidbody rigidbody;
    public targetController target;
    

    

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

    private void OnCollisionEnter(Collision body)
    {
        if(body.relativeVelocity.magnitude > 50 && !body.gameObject.tag.Contains("grab"))
        {
            Health -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("gold") && target.grabstatus == true)
        {
            target.grabstatus = false;
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,turnspeed * steerval * Time.deltaTime, 0);
        rigidbody.AddForce(transform.forward * accelval * Time.deltaTime * movespeed - rigidbody.velocity * brakeval * Time.deltaTime * brakespeed);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxspeed);
        if (Health <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0.001f;
            deathScene.DeathSceneActivate();
        }

    }
}