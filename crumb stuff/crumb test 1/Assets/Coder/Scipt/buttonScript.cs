using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] private string Scene = "Zone";
    public GameObject pausePanel;
    public bool pausecheck;
    public upgradeTrigger upgradeTrigger;
    public bool ispause;
    private float timer;


    void Awake()
    {
        timer = 0;
        pausePanel = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void IntroButton()
    {
        SceneManager.LoadScene("Intro");
    }

    public void StartGameButton()
    {
        if(timer > 3)
        {
            SceneManager.LoadScene(Scene);
            spaceshipController.Deatheventsystem.SetActive(false);
            upgradeTrigger.Pauseeventsystem.SetActive(false);
            WinningZone.collectedAllComponent = false;
        }
    }
    public void CreditScene()
    {
        SceneManager.LoadScene("UI_credits");
    }

    public void RestartGameButtonisPause()
    {
        if (upgradeTrigger.isPause)
        {
            spaceshipController.Deatheventsystem.SetActive(false);
            upgradeTrigger.Pauseeventsystem.SetActive(false);
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(Scene);
            upgradeTrigger.isPause = false;
            spaceshipController.isDead = false;
            WinningZone.collectedAllComponent = false;
        }
    }
    
    public void RestartGameButton()
    {
        if(spaceshipController.isDead)
        {
            spaceshipController.Deatheventsystem.SetActive(false);
            upgradeTrigger.Pauseeventsystem.SetActive(false);
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(Scene);
            upgradeTrigger.isPause = false;
            spaceshipController.isDead = false;
            WinningZone.collectedAllComponent = false;
        }
    }

    public void SettingsGameButton()
    {
        SceneManager.LoadScene("UI_controlselection");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void MainMenuButtonisPause()
    {
        if (upgradeTrigger.isPause)
        {
            SceneManager.LoadScene("UI_mainmenu");
            upgradeTrigger.isPause = false;
        }
    }
    
    public void MainMenuButton()
    {
        if(spaceshipController.isDead)
        {
            SceneManager.LoadScene("UI_mainmenu");
            upgradeTrigger.isPause = false;
            spaceshipController.isDead = false;
        }
    }

    public void ResumeGameButton()
    {
        pausecheck = true;
    }

    public void dechecker()
    {
        pausecheck = false;
    }

}
