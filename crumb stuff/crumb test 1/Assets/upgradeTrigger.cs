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
    static public GameObject Pauseeventsystem;
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
    public GameObject compHandler;

    //VFX
    public GameObject StarShineEffect;


    private bool HyperDriveinBound = false;
    void Awake()
    {
        StarShineEffect.SetActive(false);
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
        isPause = false;
        currentHyperDrives.text = (HyperDriveManager.HyperDriveCounter.ToString() + " oUt oF 4");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            spaceshipInbound = true;
        }
        if (other.CompareTag("HyperDriveComponents"))
        {
            compHandler.GetComponent<componentHandler>().components.Add(other.gameObject.name);
            Destroy(other.gameObject);
            StarShineEffect.SetActive(false);
            StarShineEffect.SetActive(true);
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
        Pauseeventsystem = GameObject.FindGameObjectWithTag("PauseEvent");
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;
        upgradePanel = GameObject.FindGameObjectWithTag("UpgradePanel");
        pausePanel = GameObject.FindGameObjectWithTag("PauseMenu");
        buttonController = GameObject.FindGameObjectWithTag("ButtonController");
        buttonScript = buttonController.GetComponent<buttonScript>();
        Pauseeventsystem.SetActive(false);

        compHandler = GameObject.FindGameObjectWithTag("component manager");
    }

    void Update()
    {
        Pauseeventsystem.SetActive(isPause);
        if (upgradePanel != null)
            upgradePanel.SetActive(spaceshipInbound);
        
        if (spaceshipInbound && spaceshipController.isDead == false)
        {

            if (menuButton == 1 && isPause == false)
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