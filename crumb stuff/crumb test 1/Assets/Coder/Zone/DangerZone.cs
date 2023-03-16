using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DangerZone : MonoBehaviour
{
    public GameObject wardenPrefab;
    public Animator[] anim;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            anim[0].SetBool("Alert", true);
            Instantiate(wardenPrefab);
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
