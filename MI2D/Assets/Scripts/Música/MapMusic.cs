using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMusic : MonoBehaviour
{
    public void SelectMap1(string mapSceneName)
    {
        // Cambia la música antes de cargar la nueva escena
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.Map1Music);
        }

        // Carga la escena del mapa
        SceneManager.LoadScene(mapSceneName);
    }
    public void SelectMap2(string mapSceneName)
    {
        // Cambia la música antes de cargar la nueva escena
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.Map2Music);
        }

        // Carga la escena del mapa
        SceneManager.LoadScene(mapSceneName);
    }

}
