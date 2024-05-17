using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultCount : MonoBehaviour//para las puntuaciones
{
    public Text resultText;
    public Text maxResultText;
    private float result;
    public GameObject gamePausa;
    private bool juegoPausado = false;
    public string mapName;
    void Start()//carga puntuación máxima
    {
        maxResultText.text = PlayerPrefs.GetInt(mapName + "PuntuacionRecord", 0).ToString();
    }
    void Update()//actualiza la puntuación máxima si se supera y pausar juego
    {
        if (!juegoPausado && GameObject.FindGameObjectWithTag("Player") != null)
        {
            result += 100 * Time.deltaTime;
            resultText.text = ((int)result).ToString();
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
    public void BorrarDatos()//borra la puntuación máxima de ese mapa
    {
        PlayerPrefs.DeleteKey(mapName + "PuntuacionRecord");
        maxResultText.text = "0";
    }
    void PausarJuego()//pausa
    {
        Time.timeScale = 0f; 
        gamePausa.SetActive(true);
        juegoPausado = true;
    }
    public void ReanudarJuego()//reanuda
    {
        Time.timeScale = 1f;
        gamePausa.SetActive(false);
        juegoPausado = false;
    }
}
