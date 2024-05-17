using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumenSlider : MonoBehaviour//para gestionar el volumen de la música y el de efectos
{
    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;
    public Text musicVolumeText; 
    public Text effectsVolumeText; 
    void Start()
    {
        InitializeSliders();
        musicVolumeSlider.onValueChanged.AddListener(delegate { SetMusicVolume(musicVolumeSlider.value); });
        effectsVolumeSlider.onValueChanged.AddListener(delegate { SetEffectsVolume(effectsVolumeSlider.value); });
    }
    private void InitializeSliders()
    {
        if (AudioManager.instance != null)
        {
            float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
            musicVolumeSlider.value = savedMusicVolume;
            UpdateMusicVolumeText(savedMusicVolume);
            float savedEffectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
            effectsVolumeSlider.value = savedEffectsVolume;
            UpdateEffectsVolumeText(savedEffectsVolume);
        }
    }
    public void SetMusicVolume(float volume)//el de música de fondo
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicVolume(volume);
        }
        UpdateMusicVolumeText(volume);
    }
    public void SetEffectsVolume(float volume)//el de efectos
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetEffectsVolume(volume);
        }
        UpdateEffectsVolumeText(volume);
    }
    private void UpdateMusicVolumeText(float volume)//actualizar el de música de fondo
    {
        if (musicVolumeText != null)
        {
            musicVolumeText.text = (volume * 100).ToString("F0");
        }
    }

    private void UpdateEffectsVolumeText(float volume)//actualizar el de efectos
    {
        if (effectsVolumeText != null)
        {
            effectsVolumeText.text = (volume * 100).ToString("F0");
        }
    }
}
