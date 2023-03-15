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
        if (animatorsStatic == null)
            print("null!");
        else
            print("not null!");
    }

    static public void DeathSceneActivate()
    {
        foreach (Animator anim in animatorsStatic)
        {
            anim.SetTrigger("OpenClose");
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            foreach (Animator anim in animatorsStatic)
            {
                anim.SetTrigger("OpenClose");
            }
        }
    }
}
