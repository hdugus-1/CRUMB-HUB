using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class componentHandler : MonoBehaviour
{
    public List<string> components;
    

    public static componentHandler instance;

    public void emptyTheList()
    {
        components.Clear();
    }

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
