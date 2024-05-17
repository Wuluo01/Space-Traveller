using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour//para todo lo de la música y efectos
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
    public void PlayMusic(AudioClip music)//poner música
    {
        if (audioSource.clip == music)
            return;

        audioSource.clip = music;
        audioSource.Play();
    }
    public void RestartMusic()//reiniciar música
    {
        audioSource.Stop();
        audioSource.Play();
    }
    public void StopMusic()//parar la música
    {
        audioSource.Stop();
    }
    public void SetMusicVolume(float volume)//volúmen de música de fondo
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }
    public void SetEffectsVolume(float volume)//volúmen de efectos
    {
        PlayerPrefs.SetFloat(EffectsVolumeKey, volume);
        PlayerPrefs.Save();
        UpdateAllAudioSources(volume);
    }
    private void LoadVolumes()//cargar lo guardado
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
        audioSource.volume = musicVolume;

        float effectsVolume = PlayerPrefs.GetFloat(EffectsVolumeKey, 0.5f);
        UpdateAllAudioSources(effectsVolume);
    }
    public void RegisterAudioSource(AudioSource source)//registrar
    {
        if (!allAudioSources.Contains(source))
        {
            allAudioSources.Add(source);
            float effectsVolume = PlayerPrefs.GetFloat(EffectsVolumeKey, 0.5f);
            source.volume = effectsVolume; 
        }
    }
    private void UpdateAllAudioSources(float volume)//actualizar todo
    {
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
