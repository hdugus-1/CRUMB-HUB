using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;
using Unity.Mathematics;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static SoundManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance= this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.bypassEffects= true;
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }
    }
    public void FadeIn(string name)
    {
        StartCoroutine(StartInFade(name));
    }

    public void FadeOut(string name)
    {
        StartCoroutine(StartOutFade(name));
    }
    IEnumerator StartInFade(string name)
    {
        float percentage = 0f;
        float transition = 1f;
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found. What a disappointment. Aren't you sad.");
            
        }
        s.source.volume = 0f;
        s.source.Play();

        while (s.source.volume < s.volume)
        {
            s.source.volume = math.lerp(0, s.volume, percentage);
            percentage += Time.deltaTime / transition;
            yield return null;
        }
    }
    IEnumerator StartOutFade(string name)
    {
        float percentage = 0f;
        float transition = 15f;
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found. What a disappointment. Aren't you sad.");

        }
        s.source.volume = 0f;
        s.source.Play();

        while (s.source.volume > 0)
        {
            s.source.volume = math.lerp(s.source.volume, 0, percentage);
            percentage += Time.deltaTime / transition;
            yield return null;
        }
    }    

}
