using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safezonePerimeter : MonoBehaviour
{
    bool tof=false;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spaceship" && tof==false)
        {

           // spawner.startSpawning();
            tof=true;
            Debug.Log("Entered the dangerous zone");
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Spaceship" && tof==true){
             // spawner.stopSpawning();
            tof=false;
            Debug.Log("exited the dangerous zone");
        }
    }

    public bool collisionchecker(){
        return tof;
    }
}
