using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followSpaceship : MonoBehaviour
{
    private GameObject spaceship;
   
    
    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Spaceship") != null)
        {
            transform.position = spaceship.transform.position;
        }
    }
}
