using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casualRotation : MonoBehaviour
{
    float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0, 0, 0.3f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
