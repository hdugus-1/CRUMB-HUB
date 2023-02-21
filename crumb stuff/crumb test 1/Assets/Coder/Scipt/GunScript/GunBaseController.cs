using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseController : MonoBehaviour
{

    public float rotationspeed = 5.0f;
    private Transform sphereTransform;

    // Start is called before the first frame update
    void Start()
    {
        sphereTransform= transform;
    }

    // Update is called once per frame
    public void GunBaseRotationRight()
    {
        sphereTransform.Rotate(Vector3.up, rotationspeed);
    }  
    public void GunBaseRotationLeft()
    {
        sphereTransform.Rotate(Vector3.up, -rotationspeed);
    }
}
