using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTimer : MonoBehaviour
{
    static public float maintimer;

    private void Update()
    {
        maintimer += Time.deltaTime;
        //print(Mathf.Floor(maintimer / 60));
    }

}
