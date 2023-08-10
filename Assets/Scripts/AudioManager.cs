using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private bool isSoundOn = true;
    private bool isMusicOn = true;

    public Button musicButton;
    public Button soundButton;

    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
 
            isSoundOn = PlayerPrefs.GetInt("SoundState", 1) == 1;
            isMusicOn = PlayerPrefs.GetInt("MusicState", 1) == 1;

            musicButton.image.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
            soundButton.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(0);
        musicSource.mute = !isMusicOn;
        sfxSource.mute = !isSoundOn;
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
        isMusicOn = !isMusicOn;
        musicSource.mute = !isMusicOn;

        musicButton.image.sprite = isMusicOn ? musicOnSprite : musicOffSprite;

        PlayerPrefs.SetInt("MusicState", isMusicOn ? 1 : 0);
    }

    public void ToggleSFX()
    {
        isSoundOn = !isSoundOn;
        sfxSource.mute = !isSoundOn;

       
        soundButton.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;

        PlayerPrefs.SetInt("SoundState", isSoundOn ? 1 : 0);
    }
}

