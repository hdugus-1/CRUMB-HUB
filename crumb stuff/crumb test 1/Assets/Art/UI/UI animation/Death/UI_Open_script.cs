using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Open_script : MonoBehaviour
{
    public Animator[] anim;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            foreach (var anim in anim)
            {
                anim.SetTrigger("OpenClose");
            }
        }
    }
}
