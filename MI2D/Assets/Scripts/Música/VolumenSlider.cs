using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenSlider : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;
    public Text musicVolumeText; // Opcional: para mostrar el valor del volumen
    public Text effectsVolumeText; // Opcional: para mostrar el valor del volumen

    void Start()
    {
        // Configurar los sliders y sus valores iniciales
        InitializeSliders();

        // Agregar listeners a los sliders
        musicVolumeSlider.onValueChanged.AddListener(delegate { SetMusicVolume(musicVolumeSlider.value); });
        effectsVolumeSlider.onValueChanged.AddListener(delegate { SetEffectsVolume(effectsVolumeSlider.value); });
    }

    private void InitializeSliders()
    {
        if (AudioManager.instance != null)
        {
            // Cargar y establecer el valor del slider de música
            float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
            musicVolumeSlider.value = savedMusicVolume;
            UpdateMusicVolumeText(savedMusicVolume);

            // Cargar y establecer el valor del slider de efectos
            float savedEffectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
            effectsVolumeSlider.value = savedEffectsVolume;
            UpdateEffectsVolumeText(savedEffectsVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicVolume(volume);
        }

        // Actualizar el texto del volumen si existe
        UpdateMusicVolumeText(volume);
    }

    public void SetEffectsVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetEffectsVolume(volume);
        }

        // Actualizar el texto del volumen si existe
        UpdateEffectsVolumeText(volume);
    }

    private void UpdateMusicVolumeText(float volume)
    {
        if (musicVolumeText != null)
        {
            musicVolumeText.text = (volume * 100).ToString("F0");
        }
    }

    private void UpdateEffectsVolumeText(float volume)
    {
        if (effectsVolumeText != null)
        {
            effectsVolumeText.text = (volume * 100).ToString("F0");
        }
    }
}
