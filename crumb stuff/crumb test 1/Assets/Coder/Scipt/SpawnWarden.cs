using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnWarden : MonoBehaviour
{
    public GameObject wardenPrefab;

    public void SpawnWardenTheBoss(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(wardenPrefab);
        }
    }

}
