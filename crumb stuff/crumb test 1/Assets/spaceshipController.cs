using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class spaceshipController : MonoBehaviour
{
    float vert;
    float horiz;
    float turnspeed = 75.0f;
    float movespeed = 5;

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Vertical");
        horiz = Input.GetAxis("Horizontal");
        transform.Rotate(0,0 , -horiz* turnspeed * Time.deltaTime);

       // GetComponent.<Rigidbody>().AddForce(transform.forward * -movespeed * Time.deltaTime * vert);
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody>().AddForce(transform.forward * movespeed * Time.deltaTime);
    }
}
