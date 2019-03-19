using UnityEngine.Audio;
using UnityEngine;

//Using code inspired by: https://www.youtube.com/watch?v=6OT43pvUyfY&t=577s

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;


}
