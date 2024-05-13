using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    float linToLog(float linear)
    {
        return Mathf.Log10(linear) * 20f;
    }
    float logToLin(float logarithmic)
    {
        return Mathf.Pow(10f, logarithmic / 20f);
    }
    [SerializeField] private AudioMixer mixer;
    private const string MASTER_VOLUME_PARAM = "MasterVolume";
    private const string MUSIC_VOLUME_PARAM = "MusicVolume";
    private const string SFX_VOLUME_PARAM = "SFXVolume";
    public float GetMasterVolume()
    {
        mixer.GetFloat(MASTER_VOLUME_PARAM, out float vol);
        return logToLin(vol);
    }
    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat(MASTER_VOLUME_PARAM, linToLog(volume));
    }
    public float GetMusicVolume()
    {
        mixer.GetFloat(MUSIC_VOLUME_PARAM, out float vol);
        return logToLin(vol);
    }
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat(MUSIC_VOLUME_PARAM, linToLog(volume));
    }
    public float GetSFXVolume()
    {
        mixer.GetFloat(SFX_VOLUME_PARAM, out float vol);
        return logToLin(vol);
    }
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat(SFX_VOLUME_PARAM, linToLog(volume));
    }

}
