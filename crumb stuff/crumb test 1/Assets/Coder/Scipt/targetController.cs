using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class targetController : MonoBehaviour
{
    public Animator[] anim;

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

    private void Awake()
    {
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
        basespeed = shipcontroller.movespeed;
        basemaxspeed = shipcontroller.maxspeed;
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
            shipcontroller.movespeed = basespeed/2;
            shipcontroller.maxspeed = basemaxspeed / 2;

        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oldpos = transform.position;
        transform.position = Vector3.Lerp(oldpos, new Vector3(target.position.x + ballpoint.x * grabLength, target.position.y, target.position.z + ballpoint.y * grabLength),lerptime);
        
        if(thing == null)
        {
            grabstatus = false;
        }
        if (grabby == 1 && grabstatus == true)
        {
            thing.transform.position = transform.position;
            thing.attachedRigidbody.velocity = Vector3.zero;
        }

        if (grabby == 0 && grabstatus == true)
        {
            thing.attachedRigidbody.AddForce(ship.velocity + ((transform.position - oldpos) / Time.deltaTime) * 50);
            grabstatus = false;
            shipcontroller.movespeed = basespeed;
            shipcontroller.maxspeed = basemaxspeed;
        }
        
        
    }
}
