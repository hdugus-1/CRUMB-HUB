using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;
using Unity.Mathematics;

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
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }
    }

   public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found. What a disappointment. Aren't you sad.");
            return;
        }
          
        s.source.Play();
    }

    public void StopPlay(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found. What a disappointment. Aren't you sad.");
            return;
        }

        s.source.Stop();
    }

    public void FadeIn(string name)
    {
        float percentage = 0f;
        float transition = 100f;
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found. What a disappointment. Aren't you sad.");
            return;
        }
        s.source.volume = 0f;
        s.source.Play();
        while (s.source.volume < s.volume)
        {
            s.source.volume = math.lerp(0, s.volume, percentage);
            Debug.Log(s.source.volume);
            percentage += Time.deltaTime / transition;
        }
    }

    public void FadeOut(string name)
    {
        float percentage = 0f;
        float transition = 100f;
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found. What a disappointment. Aren't you sad.");
            return;
        }
        while (s.source.volume > 0)
        {
            s.source.volume = math.lerp(s.source.volume, 0, percentage);
            Debug.Log(s.source.volume);
            percentage += Time.deltaTime / transition;
        }
        s.source.Stop();
    }
    private void Start()
    {
        FindObjectOfType<SoundManager>().FadeIn("main");
    }
    
}
