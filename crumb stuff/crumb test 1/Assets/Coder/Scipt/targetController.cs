using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class targetController : MonoBehaviour
{
    public AudioSource GrabSound;
    public Animator[] anim;

    //Added temporary variables for grab arm
    public Transform joint1;
    public Transform joint2;
    public float grabOpenGap = 20;

    public Transform target;
    public Rigidbody Grabbed;
    public Rigidbody ship;
    public spaceshipController shipcontroller;
    public float basespeed;
    public float basemaxspeed;
    public Collider thing;
    Vector2 ballpoint;
    public float grabby;
    public bool grabstatus = false;
    Vector3 oldpos;
    public float lerptime = 0.5f;
    public float grabLength = 3;
    private PlayerInput playerinput;
    private Controls playercontrols;

    private bool speedReduced = false;
    float tempMaxSpeed;
    float tempMoveSpeed;

    private bool playedGrabSound = false;
    private void Awake()
    {
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
    }

    private void Start()
    {
        tempMaxSpeed = shipcontroller.maxspeed;
        tempMoveSpeed = shipcontroller.movespeed;
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
        ballpoint = context.ReadValue<Vector2>();
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        grabby = context.ReadValue<float>();
    }

    private void OnTriggerStay(Collider other)
    {
        float speedWhenGrab = 0.45f;
        if (other.tag.Contains("grab") && grabby == 1)
        {
            grabstatus = true;
            thing = other;
            
        }
        if(other.tag.Contains("HyperDriveComponents") && grabby == 1)
        {
            anim[0].SetBool("Alert", true);
            grabstatus = true;
            thing = other;
            if(!speedReduced)
            {
                shipcontroller.movespeed *= speedWhenGrab;
                shipcontroller.maxspeed *= speedWhenGrab;
                speedReduced= true;
            }
        }
        
    }

    void Update()
    {
        if(grabby != 1)
        {
            shipcontroller.movespeed = tempMoveSpeed;
            shipcontroller.maxspeed = tempMaxSpeed;
            speedReduced = false;
        }

        oldpos = transform.position;
        transform.position = Vector3.Lerp(oldpos, new Vector3(target.position.x + ballpoint.x * grabLength, target.position.y, target.position.z + ballpoint.y * grabLength),lerptime);
        
        if(thing == null)
        {
            grabstatus = false;
        }
        if(grabby == 1 && joint1 != null && joint2 != null) //Close grab arm
        {
            if (!GrabSound.isPlaying && !playedGrabSound) 
            { 
                GrabSound.Play();   
                playedGrabSound = true;

            }
            joint1.localRotation = Quaternion.Euler(0, 0, 0);
            joint2.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (grabby == 1 && grabstatus == true)
        {
            thing.transform.position = transform.position;
            thing.attachedRigidbody.velocity = Vector3.zero;
        }

        if (grabby == 0 && joint1 != null && joint2 != null) //open grab arm
        {
            if (playedGrabSound) playedGrabSound = false;
            joint1.localRotation = Quaternion.Euler(0, -grabOpenGap, 0);
            joint2.localRotation = Quaternion.Euler(0, grabOpenGap, 0);
        }
        if (grabby == 0 && grabstatus == true)
        {
            thing.attachedRigidbody.AddForce(ship.velocity + ((transform.position - oldpos) / Time.deltaTime) * 50);
            grabstatus = false;
            //shipcontroller.movespeed = basespeed;
            //shipcontroller.maxspeed = basemaxspeed;
        }
        
        
    }
}
