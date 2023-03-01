using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perimeter : MonoBehaviour
{
    spawn spawner;

    
    bool tof=false;
    // Start is called before the first frame update
    private void Start() {
        spawner=GameObject.FindGameObjectWithTag("spawner").GetComponent<spawn>();
    }


    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Spaceship" && tof==false){
            spawner.startSpawning();
            tof=true;
            
        }
        else if(other.tag=="Spaceship" && tof==true){
            GameObject[] asteroids=GameObject.FindGameObjectsWithTag("asteroid");
            spawner.stopSpawning();
            tof=false;
            for(int i=0;i<asteroids.Length;i++){
                Destroy(asteroids[i]);
            }
        }
    }
    
}
