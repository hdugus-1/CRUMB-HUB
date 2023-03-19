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
        foreach (Animator anim in animatorsStatic)
        {
            anim.SetTrigger("OpenClose");
        }
    }

}
