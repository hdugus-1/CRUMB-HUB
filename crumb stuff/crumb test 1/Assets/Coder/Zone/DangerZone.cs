using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DangerZone : MonoBehaviour
{
    public GameObject wardenPrefab;
    public AudioSource WardenWarningSound;
    public Animator[] anim;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            GameObject musicManager = GameObject.FindGameObjectWithTag("MusicManager");
            if (musicManager != null)
            {
                musicManager.GetComponent<PlaySound>().soundToFadeTo = "chase";
            }
            anim[0].SetBool("Alert", true);
            Instantiate(wardenPrefab);
            if (WardenWarningSound != null) WardenWarningSound.Play();
            else Debug.LogWarning("No warden popup sound detected");
        }
    }
}
