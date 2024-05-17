using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MostrarVida : MonoBehaviour//para mostrar la vida
{
    public Text healthText; 
    public Vidas playerVidas; 
    void Start()
    {
        UpdateHealthText();
    }
    void Update()
    {
        UpdateHealthText();
    }
    void UpdateHealthText()
    {
        healthText.text = playerVidas.health.ToString();
    }
}
