using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScene : MonoBehaviour
{

    public Animator[] animators;

    static Animator[] animatorsStatic;
    void Awake()
    {
        animatorsStatic = animators;
    }

    static public void DeathSceneActivate()
    {
        GameObject musicManager = GameObject.FindGameObjectWithTag("MusicManager");
        if (musicManager != null)
        {
            musicManager.GetComponent<PlaySound>().soundToFadeTo = "main";
        }
        foreach (Animator anim in animatorsStatic)
        {
            anim.SetTrigger("OpenClose");
        }
    }

}
