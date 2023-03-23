using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalTimer : MonoBehaviour
{
    private float min, sec;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        min = Mathf.Floor(MainTimer.maintimer / 60);
        sec = Mathf.Floor(MainTimer.maintimer % 60);
        timerText.text =  min.ToString() + " miN " + sec.ToString() + " sEc";
    }
    void Update()
    {
        print(sec);
    }
}
