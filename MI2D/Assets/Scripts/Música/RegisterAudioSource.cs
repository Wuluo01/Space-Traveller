using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RegisterAudioSource : MonoBehaviour//para registrar los efectos
{
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (AudioManager.instance != null)
        {
            AudioManager.instance.RegisterAudioSource(audioSource);
        }
    }
}
