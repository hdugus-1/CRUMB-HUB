using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] private string Scene = "Zone";
    public GameObject pausePanel;
    public bool pausecheck;
    public upgradeTrigger upgradeTrigger;
    public bool ispause;


    void Awake()
    {

        pausePanel = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(Scene);
    }

    public void RestartGameButton()
    {
        if (upgradeTrigger.isPause)
        {
            SceneManager.LoadScene(Scene);
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

    public void MainMenuButton()
    {
        if (upgradeTrigger.isPause)
        {
            SceneManager.LoadScene("UI_mainmenu");
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

    void Update()
    {
        
    }
}
