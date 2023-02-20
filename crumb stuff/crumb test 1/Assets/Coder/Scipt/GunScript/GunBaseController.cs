using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseController : MonoBehaviour
{

    public float rotationspeed = 10.0f;
    private Transform sphereTransform;

    // Start is called before the first frame update
    void Start()
    {
        sphereTransform= transform.parent;
    }

    // Update is called once per frame
    public void GunBaseRotation()
    {
        sphereTransform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
    }
}
