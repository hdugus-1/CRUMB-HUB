using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HyperDriveManager : MonoBehaviour
{
    public static HyperDriveManager instance;
    public TextMeshProUGUI currentHyperDrives;

    static public int HyperDriveCounter = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //currentHyperDrives.text = HyperDriveCounter.ToString();
    }
}
