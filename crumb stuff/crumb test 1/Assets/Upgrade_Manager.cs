using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrade_Manager : MonoBehaviour
{
    public GameObject minimap;

    private void Start()
    {
        GameObject spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        minimap = spaceship.transform.Find("Minimap").gameObject;
       
            minimap = GameObject.FindGameObjectWithTag("Spaceship");
            if (minimap == null)
            {
                Debug.LogError("Spaceship not found in scene or not tagged with 'Spaceship'.");
            }
        
    }


    public void ActivateMinimap()
    {
        minimap.SetActive(true);
    }
}
