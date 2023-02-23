using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class upgradeTrigger : MonoBehaviour
{
    public Transform spaceshipTransform;
    public bool spaceshipInbound;
    public GameObject upgradePanel;
    public Controls controls;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            spaceshipInbound = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            spaceshipInbound = false;
        }

    }

    void Awake()
    {
        controls = new Controls();
    }

    void Start()
    {
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;
        upgradePanel = GameObject.FindGameObjectWithTag("UpgradePanel");
    }

    void Update()
    {  
        upgradePanel.SetActive(spaceshipInbound);
        if (spaceshipInbound)
        {
            
            if (Input.GetKeyDown("u"))
            {
                SceneManager.LoadScene("upgradeMenu");
            }
            
            
        }
    }
    
    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

}
