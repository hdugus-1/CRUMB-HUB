using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public void BackToGame()
    {
        SceneManager.LoadScene("Zone");
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("UI_mainmenu");
    }

}
