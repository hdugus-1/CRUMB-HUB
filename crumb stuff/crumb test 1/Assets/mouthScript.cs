using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthScript : MonoBehaviour
{

    public targetController target;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("gold") && target.grabstatus == true)
        {
            target.grabstatus = false;
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
