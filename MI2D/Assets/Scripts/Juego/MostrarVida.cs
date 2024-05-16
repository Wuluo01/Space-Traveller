using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarVida : MonoBehaviour
{
    public Text healthText; // Referencia al componente de texto del UI
    public Vidas playerVidas; // Referencia al script Vidas del jugador

    void Start()
    {

        UpdateHealthText();
    }

    void Update()
    {
        // Actualizar la UI cada frame
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + playerVidas.health.ToString();
    }
}
