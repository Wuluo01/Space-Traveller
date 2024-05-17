using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapMusic : MonoBehaviour//para cargar la música y el mapa seleccionado
{
    public void SelectMap1(string mapSceneName)//para el mapa 1
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.Map1Music);
        }
        SceneManager.LoadScene(mapSceneName);
    }
    public void SelectMap2(string mapSceneName)//para el mapa 2
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.Map2Music);
        }
        SceneManager.LoadScene(mapSceneName);
    }
}
