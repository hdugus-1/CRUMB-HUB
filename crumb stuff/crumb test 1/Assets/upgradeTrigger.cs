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
    public GameObject pausePanel;
    private PlayerInput playerinput;
    private Controls playercontrols;
    private float menuButton;
    private float pauseButton;
    private bool realmenubutton;
    public bool isPause = false;

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

    
    public void OnPauseResume()
    {
        isPause = false;
    }
    
    void Start()
    {
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;
        upgradePanel = GameObject.FindGameObjectWithTag("UpgradePanel");
        pausePanel = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    void Update()
    {  
        upgradePanel.SetActive(spaceshipInbound);
        pausePanel.SetActive(isPause);
        if (spaceshipInbound)
        {
            
            if (menuButton == 1)
            {
                SceneManager.LoadScene("upgradeMenu");
            }
            
            
        }
        if (playercontrols.Player.pause.ReadValue<float>() == 1)
        {
            isPause = true;
        }
        if (isPause)
        {
            Time.timeScale = 0;
        }
    }
    
    

}
