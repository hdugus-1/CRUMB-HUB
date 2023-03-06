using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_script : MonoBehaviour
{
    public ParticleSystem[] particleSys;
    public GameObject ship;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z) && particleSys != null)
        {
            particleSys[0].Play();
            StartCoroutine(ExecuteAfterTime(0.3f));
            
            
        }
        if (Input.GetKeyDown(KeyCode.X) && particleSys != null)
        {
            particleSys[1].Play();
        }
        if (Input.GetKeyDown(KeyCode.C) && particleSys != null)
        {
            particleSys[2].Play();
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(ship);
        // Code to execute after the delay
    }
}
