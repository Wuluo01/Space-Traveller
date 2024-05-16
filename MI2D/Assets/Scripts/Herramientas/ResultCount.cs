using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultCount : MonoBehaviour
{
    public Text resultText;
    public Text maxResultText;
    private float result;
    public GameObject gamePausa;
    private bool juegoPausado = false;

    // Nombre único para identificar el mapa
    public string mapName;

    void Start()
    {
        // Cargar la puntuación máxima específica del mapa
        maxResultText.text = PlayerPrefs.GetInt(mapName + "PuntuacionRecord", 0).ToString();
    }

    void Update()
    {
        if (!juegoPausado && GameObject.FindGameObjectWithTag("Player") != null)
        {
            result += 100 * Time.deltaTime;
            resultText.text = ((int)result).ToString();

            // Actualizar la puntuación máxima si se supera
            if (result > PlayerPrefs.GetInt(mapName + "PuntuacionRecord", 0))
            {
                PlayerPrefs.SetInt(mapName + "PuntuacionRecord", (int)result);
                maxResultText.text = result.ToString();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (juegoPausado)
                {
                    ReanudarJuego();
                }
                else
                {
                    PausarJuego();
                }
            }
        }
    }

    public void BorrarDatos()
    {
        // Borrar la puntuación máxima específica del mapa
        PlayerPrefs.DeleteKey(mapName + "PuntuacionRecord");
        maxResultText.text = "0";
    }

    void PausarJuego()
    {
        Time.timeScale = 0f; // Congelar el tiempo del juego
        gamePausa.SetActive(true);
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        gamePausa.SetActive(false);
        juegoPausado = false;
    }
}
