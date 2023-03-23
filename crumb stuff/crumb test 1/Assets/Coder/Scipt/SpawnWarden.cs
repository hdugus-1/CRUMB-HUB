using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnWarden : MonoBehaviour
{
    public GameObject wardenPrefab;
    public Animator[] anim;

    
    public void SpawnWardenTheBoss(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            anim[0].SetBool("Alert", true);
            Instantiate(wardenPrefab);
        }
    }
    
}
