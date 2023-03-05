using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perimeter : MonoBehaviour
{
    public Spawner spawner;


    public bool tof = false;
    // Start is called before the first frame update
    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<Spawner>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spaceship" && tof == false)
        {
            spawner.startSpawning();


        }

    }
    private void OnTriggerExit(Collider other)
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
        spawner.stopSpawning();

        for (int i = 0; i < asteroids.Length; i++)
        {
            Destroy(asteroids[i]);
        }
    }

}
