using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perimeter : MonoBehaviour
{
    public Spawner spawner;


    bool tof = false;
    // Start is called before the first frame update
    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spaceship")
        {
            spawner.startSpawning();
            

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spaceship")
        {
            spawner.stopSpawning();


        }

    }
}
