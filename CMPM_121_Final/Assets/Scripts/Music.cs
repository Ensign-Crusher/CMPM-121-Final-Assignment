using UnityEngine.Audio;
using System;
using UnityEngine;

//Using code inspired by: https://www.youtube.com/watch?v=6OT43pvUyfY&t=577s

public class Music : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
        if(s == null)
        {
            print("Sound: " + name + " not found");
            return;
        }
    }
}
