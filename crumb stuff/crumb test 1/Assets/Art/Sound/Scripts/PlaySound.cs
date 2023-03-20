using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public string soundToFadeTo;
    string OldsoundName;
    static SoundManager soundManager;
    void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        OldsoundName = soundToFadeTo;
        if (soundManager == null)
            Debug.LogWarning("No sound manager");
        else if (soundManager != null)
            soundManager.soundTransistion(soundToFadeTo);
    }
    private void Update()
    {
        if(soundToFadeTo != OldsoundName)
        {
            soundManager.soundTransistion(soundToFadeTo);
            OldsoundName = soundToFadeTo;
        }
    }
}
