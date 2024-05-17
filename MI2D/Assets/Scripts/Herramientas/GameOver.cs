using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour//para todo lo de game over
{
    public GameObject gameOverPanel;
    public GameObject dejarSpawnearEnemigo;
    public GameObject dejarSpawnearVidas;
    public GameObject dejarSpawnearBombas;
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
            dejarSpawnearEnemigo.SetActive(false);
            dejarSpawnearVidas.SetActive(false);
            dejarSpawnearBombas.SetActive(false);
        }
    }
    public void Restart()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.RestartMusic();
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Map1ToMapas()//cambiar al mapa 1 y cambiar la música
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.splashToMapsMusic);
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Map2ToMapas()//cambiar al mapa 2 y cambiar la música
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.splashToMapsMusic);
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
