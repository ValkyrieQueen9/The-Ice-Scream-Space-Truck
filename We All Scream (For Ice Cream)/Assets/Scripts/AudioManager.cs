using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;

    public float masterVolume;
    public Sound[] sounds;

    [HideInInspector]
    public bool TimesUpFinished;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }

        Sound theme = Array.Find(sounds, sound => sound.name == "Theme");
        volumeSlider.value = theme.source.volume;

        PlaySound("Theme");
    }

    private void Update()
    {
        if(SoundFinished("TimesUp"))
        {
            TimesUpFinished = true;
        }
    }

    public void PlaySound (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void VolumeChange(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        s.source.volume = volumeSlider.value;
    }

    public bool SoundFinished (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.time == s.clip.length)
        {
            return true;
        }
        else
            return false;
    }

}
