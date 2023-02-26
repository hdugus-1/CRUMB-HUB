using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerZone : MonoBehaviour
{
    public GameObject wardenPrefab;
 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            Instantiate(wardenPrefab, transform.position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
