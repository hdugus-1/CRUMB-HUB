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
        if (other.tag == "Spaceship" && tof==false)
        {

           spawner.startSpawning();
            tof=true;
            Debug.Log("entered");
            
        }
        else if(other.tag=="Spaceship" && tof==true){
            spawner.stopSpawning();
            tof=false;
           Debug.Log("exited");
        }
        
    }
    
}
