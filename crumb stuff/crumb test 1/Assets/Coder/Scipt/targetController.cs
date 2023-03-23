using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class targetController : MonoBehaviour
{
    public Transform target;
    public Rigidbody ship;
<<<<<<< Updated upstream
    public Collider thing;
=======
    public spaceshipController shipcontroller;
    public float basespeed;
    public float basemaxspeed;
    public Collider GrabbedThing;
>>>>>>> Stashed changes
    Vector2 ballpoint;
    public float grabby;
    public bool grabstatus = false;
    Vector3 oldpos;
    
    float sens = 3;
    private PlayerInput playerinput;
    private Controls playercontrols;

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
<<<<<<< Updated upstream
           
            Debug.Log("grabbed");
            //other.attachedRigidbody.velocity = Vector3.zero;
            thing = other;
            
        }

    }
    // Start is called before the first frame update
    void Start()
    {
=======
            GrabbedThing = other;
            
        }
        if(other.tag.Contains("HyperDriveComponents") && grabby == 1)
        {
            anim[0].SetBool("Alert", true);
            grabstatus = true;
            GrabbedThing = other;
            if(!speedReduced)
            {
                shipcontroller.movespeed *= speedWhenGrab;
                shipcontroller.maxspeed *= speedWhenGrab;
                speedReduced= true;
            }
        }
>>>>>>> Stashed changes
        
    }

    // Update is called once per frame
    void Update()
    {
        oldpos = transform.position;
        transform.position = new Vector3(target.position.x + ballpoint.x * sens, target.position.y, target.position.z + ballpoint.y * sens);
        
        if(GrabbedThing == null)
        {
            grabstatus = false;
        }
        if (grabby == 1 && grabstatus == true)
        {
            GrabbedThing.transform.position = transform.position;
            GrabbedThing.attachedRigidbody.velocity = Vector3.zero;
        }

        if (grabby == 0 && grabstatus == true)
        {
            GrabbedThing.attachedRigidbody.AddForce(ship.velocity + ((transform.position - oldpos) / Time.deltaTime) * 50);
            grabstatus = false;
        }
        
        
    }
}
