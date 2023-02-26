using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class targetController : MonoBehaviour
{
    public Transform target;
    public Rigidbody Grabbed;
    public Rigidbody ship;
    public Collider thing;
    Vector2 ballpoint;
    float grabby;
    bool grabstatus = false;
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
        
        if (other.CompareTag("grabbable") && grabby == 1)
        {
            grabstatus = true;
           
            Debug.Log("grabbed");
            //other.attachedRigidbody.velocity = Vector3.zero;
            thing = other;
            
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
        transform.position = new Vector3(target.position.x + ballpoint.x * sens, target.position.y, target.position.z + ballpoint.y * sens);
        if (grabby == 1 && grabstatus == true)
        {
            thing.transform.position = transform.position;
            thing.attachedRigidbody.velocity = Vector3.zero;
        }

        if (grabby == 0 && grabstatus == true)
        {
            thing.attachedRigidbody.AddForce(ship.velocity + ((transform.position - oldpos) / Time.deltaTime) * 50);
            grabstatus = false;
        }
        
        
    }
}