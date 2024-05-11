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

    // Update is called once per frame
    void Start()
    {
        maxResultText.text = PlayerPrefs.GetInt("PuntuacionRecord", 0).ToString();
    }
    void Update()
    {
        if (!juegoPausado && GameObject.FindGameObjectWithTag("Player") != null)
        {
            result += 100 * Time.deltaTime;
            resultText.text = ((int)result).ToString();
            if (result > PlayerPrefs.GetInt("PuntuacionRecord",0))
            {
                PlayerPrefs.SetInt("PuntuacionRecord", (int)result);
                maxResultText.text = result.ToString();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                    PausarJuego();
            }
        }
    }

    public void BorrarDatos()
    {
        PlayerPrefs.DeleteKey("PuntuacionRecord");
        maxResultText.text = "0";
    }

    void PausarJuego()
    {
        Time.timeScale = 0f; // Congelar el tiempo del juego
        gamePausa.SetActive(true);
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f;
        gamePausa.SetActive(false);// Reanudar el tiempo del juego
    }

}
