using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Contexts;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunBaseController : MonoBehaviour
{

    public float rotationspeed = 5.0f;
    public float gunleft;
    public float gunright;
    private Transform sphereTransform;

    // Start is called before the first frame update
    void Start()
    {
        sphereTransform= transform;
    }

    private void Update()
    {
        sphereTransform.Rotate(Vector3.up, (gunright - gunleft) * rotationspeed * Time.deltaTime);
    }

    // Update is called once per frame
    public void GunBaseRotationRight(InputAction.CallbackContext context)
    {
        //sphereTransform.Rotate(Vector3.up, rotationspeed);
        gunright = context.ReadValue<float>();
        Debug.Log(gunright);
    }  
    public void GunBaseRotationLeft(InputAction.CallbackContext context)
    {
        //sphereTransform.Rotate(Vector3.up, -rotationspeed);
        gunleft = context.ReadValue<float>();
    }
}
