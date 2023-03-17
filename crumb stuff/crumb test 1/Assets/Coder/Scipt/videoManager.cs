using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class videoManager : MonoBehaviour
{
    public VideoPlayer player;
    [SerializeField] private string Scene = "UI_controls";
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
            SceneManager.LoadScene(Scene);
    }


    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(53);
        SceneManager.LoadScene(Scene);

    }
}
