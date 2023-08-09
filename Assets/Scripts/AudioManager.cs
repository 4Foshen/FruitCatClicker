using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        PlayMusic(0);
    }


    public void PlayMusic(int index)
    {
        if (index < 0 || index >= musicSounds.Length)
        {
            Debug.Log("Invalid index for music");
            return;
        }

        musicSource.clip = musicSounds[index].clip;
        musicSource.Play();
    }

    public void PlaySFX(int index)
    {
        if (index < 0 || index >= sfxSounds.Length)
        {
            Debug.Log("Invalid index for sfx");
            return;
        }

        sfxSource.clip = sfxSounds[index].clip;
        sfxSource.Play();
    }

    public void PlayRandomSFX(int index)
    {
        if (index < 0 || index >= sfxSounds.Length)
        {
            Debug.Log("Invalid index for sfx");
            return;
        }

        Sound randomSound = sfxSounds[index];
        sfxSource.clip = randomSound.clip;
        sfxSource.Play();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;

    }
}

