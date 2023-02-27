using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] private string Scene = "Zone";
    
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
        Time.timeScale = 1;
    }
}
