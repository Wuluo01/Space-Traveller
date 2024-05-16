using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip splashToMapsMusic;
    public AudioClip Map1Music;
    public AudioClip Map2Music;
    private float pausedTime;
    private AudioSource audioSource;

    private const string MusicVolumeKey = "MusicVolume";
    private const string EffectsVolumeKey = "EffectsVolume";
    private List<AudioSource> allAudioSources = new List<AudioSource>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            LoadVolumes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic(splashToMapsMusic);
    }

    public void PlayMusic(AudioClip music)
    {
        if (audioSource.clip == music)
            return;

        audioSource.clip = music;
        audioSource.Play();
    }

    public void RestartMusic()
    {
        audioSource.Stop();
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat(EffectsVolumeKey, volume);
        PlayerPrefs.Save();
        UpdateAllAudioSources(volume);
    }

    private void LoadVolumes()
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
        audioSource.volume = musicVolume;

        float effectsVolume = PlayerPrefs.GetFloat(EffectsVolumeKey, 0.5f);
        UpdateAllAudioSources(effectsVolume);
    }

    public void RegisterAudioSource(AudioSource source)
    {
        if (!allAudioSources.Contains(source))
        {
            allAudioSources.Add(source);
            float effectsVolume = PlayerPrefs.GetFloat(EffectsVolumeKey, 0.5f);
            source.volume = effectsVolume; // Set the initial volume
        }
    }

    private void UpdateAllAudioSources(float volume)
    {
        // Eliminar referencias nulas antes de actualizar el volumen
        allAudioSources.RemoveAll(source => source == null);

        foreach (AudioSource source in allAudioSources)
        {
            if (source != null)
            {
                source.volume = volume;
            }
        }
    }
}
