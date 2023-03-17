using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class videoManager : MonoBehaviour
{
    public VideoPlayer player;
    public float time;

    private void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }
    private void Update()
    {
        time += Time.deltaTime;

    }

    public void SkipButton()
    {
        if(time >= 3)
            SceneManager.LoadScene("Zone");
    }


    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(53);
        SceneManager.LoadScene("Zone");

    }
}
