using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

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
    static public bool isPause = false;
    public GameObject buttonController;
    public buttonScript buttonScript;
    public bool pauseanimcheck = false;
    public Animator[] anim;
    private float HUDopener;
    public TextMeshProUGUI currentHyperDrives;
    

    private bool HyperDriveinBound = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            spaceshipInbound = true;
        }
        if (other.CompareTag("HyperDriveComponents"))
        {
            Destroy(other.gameObject);
            if(HyperDriveManager.HyperDriveCounter < 4)
            {
                HyperDriveManager.HyperDriveCounter++;
                currentHyperDrives.text = (HyperDriveManager.HyperDriveCounter.ToString() + " oUt oF 4"); 
            }
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
        isPause = false;
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
        isPause = false;
    }

    public void OnPauseResume()
    {
        isPause = false;
    }

    public void HUD(InputAction.CallbackContext context)
    {
        HUDopener = context.ReadValue<float>();
        if (HUDopener == 1)
        {
            anim[4].SetBool("Open", true);
        }
        else
        {
            anim[4].SetBool("Open", false);
        }
    }

    void Start()
    {
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;
        upgradePanel = GameObject.FindGameObjectWithTag("UpgradePanel");
        pausePanel = GameObject.FindGameObjectWithTag("PauseMenu");
        buttonController = GameObject.FindGameObjectWithTag("ButtonController");
        buttonScript = buttonController.GetComponent<buttonScript>();
    }

    void Update()
    {
        if (upgradePanel != null)
            upgradePanel.SetActive(spaceshipInbound);
        
        if (spaceshipInbound)
        {

            if (menuButton == 1)
            {
                SceneManager.LoadScene("UI_Shop");
            }


        }
        if (playercontrols.Player.pause.ReadValue<float>() == 1 && spaceshipController.isDead == false)
        {
            isPause = true;
            
        }
        if (isPause)
        {
            Time.timeScale = 0;
            if (pauseanimcheck == false)
            {
                for(int i = 0; i < 4; i++)
                {
                    anim[i].SetTrigger("OpenClose");
                }
                pauseanimcheck = true;
            }
            

            if (playercontrols.Player.unPause.ReadValue<float>() == 1)
            {
                isPause = false;
                for(int i = 0; i < 4; i++)
                {
                    anim[i].SetTrigger("OpenClose");
                }
                pauseanimcheck = false;
            }
        }
        else
        {
            buttonScript.Invoke("dechecker", 3);
            Time.timeScale = 1;
        }

    }
}