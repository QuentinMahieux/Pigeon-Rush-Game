using System;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{
    public static AudioMananger instance;
    
    public AudioSource audioSource;

    [Header("Audio Clip")]
    public AudioClip audioSeletLevel;
    public AudioClip audioGame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(gameObject);
        }
    }


    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
        Debug.Log(volume);
    }

    public void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
