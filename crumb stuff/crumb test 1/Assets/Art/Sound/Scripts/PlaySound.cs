using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] string soundToFadeTo;
    static SoundManager soundManager;
    void Start()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        if (soundManager == null)
            Debug.LogWarning("No sound manager");
        else if (soundManager != null)
            soundManager.soundTransistion(soundToFadeTo);
    }
}
