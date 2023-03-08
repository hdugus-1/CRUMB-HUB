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
    public float turnspeed = 150.0f;    //75
    public float movespeed = 600.0f;   //300
    public float maxspeed = 40.0f;     //20
    float brakespeed = 100.0f;
    float steerval;
    float accelval;
    float brakeval;
    private PlayerInput playerinput;
    private Controls playercontrols;
    public new Rigidbody rigidbody;
    public targetController target;

    public GameObject Explosion;


    private void Awake()
    {
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
        Explosion.SetActive(false);
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
        rigidbody.AddTorque(0,turnspeed * steerval * Time.deltaTime, 0);
        rigidbody.AddForce(transform.forward * accelval * Time.deltaTime * movespeed - rigidbody.velocity * brakeval * Time.deltaTime * brakespeed);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxspeed);

    }


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidBody = collision.rigidbody;
        if (collision.gameObject.CompareTag("Warden"))
        {
            Explosion.SetActive(true);
        }
    }

}