using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject dejarSpawnearEnemigo;
    public GameObject dejarSpawnearVidas;
    public GameObject dejarSpawnearBombas;
    // Update is called once per frame
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
    public void Map1ToMapas()
    {
        // Cambia la música antes de cargar la escena del menú
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.splashToMapsMusic);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void Map2ToMapas()
    {
        // Cambia la música antes de cargar la escena del menú
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.splashToMapsMusic);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }
}
