using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//using System.Runtime.Remoting.Proxies;

public class upgradeTrigger : MonoBehaviour
{
    public Transform spaceshipTransform;
    public bool spaceshipInbound;
    public GameObject upgradePanel;
    private PlayerInput playerinput;
    private Controls playercontrols;
    private float menuButton;
    private bool realmenubutton;

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
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
    }

    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void OnUpgradeMenu(InputAction.CallbackContext context)
    {
        menuButton = context.ReadValue<float>();
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
            
            if (realmenubutton == true)
            {
                SceneManager.LoadScene("upgradeMenu");
            }
            
            if ( menuButton == 1)
            {
                realmenubutton = true;
            }
            else
            {
                realmenubutton = false;
            }
        }
    }
    
    

}
