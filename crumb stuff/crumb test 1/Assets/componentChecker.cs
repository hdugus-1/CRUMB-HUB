using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class componentChecker : MonoBehaviour
{

    public GameObject compHandler;

    // Start is called before the first frame update
    void Start()
    {
        compHandler = GameObject.FindGameObjectWithTag("component manager");
        

        if (compHandler.GetComponent<componentHandler>().components.Contains(gameObject.name))
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
