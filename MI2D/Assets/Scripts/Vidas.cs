using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public static Vidas Instance { get; private set; }
    public GameObject[] vidas;
    private int vidasTotales = 3;

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
    public void PerderVida()
    {
        vidasTotales -= 1;

        if (vidasTotales == 0)
        {
            Destroy(player.gameObject);
        }

        DesactivarVida(vidasTotales);
    }

    public bool RecuperarVida()
    {
        if (vidasTotales == 3)
        {
            return false;
        }

        ActivarVida(vidasTotales);
        vidasTotales += 1;
        return true;
    }
}
