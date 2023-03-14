using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuScript : MonoBehaviour
{
    [SerializeField] private string Scene = "Zone";

    public void Start()
    {
        FindObjectOfType<SoundManager>().FadeOut("win");
        FindObjectOfType<SoundManager>().FadeOut("chase");
        FindObjectOfType<SoundManager>().FadeOut("area");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(Scene);
        PlayerPrefs.DeleteAll();
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("UI_credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("UI_mainmenu");
    }
}
