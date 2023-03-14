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
            tof=true;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Spaceship" && tof==true){
            tof=false;
        }
    }

    public bool collisionchecker(){
        return tof;
    }
}
