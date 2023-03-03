using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] private string Scene = "Zone";
    public GameObject pausePanel;
    public bool pausecheck;


    void Awake()
    {
        pausePanel = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(Scene);
    }

    public void SettingsGameButton()
    {
        SceneManager.LoadScene("UI_controlselection");
    }

    public void ExitGameButton()
    {
        Application.Quit();
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
