using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake() {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }


        Play("Background Music");
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.source.Play();
    }

    public void stopSound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.source.Stop();
    }
}   
