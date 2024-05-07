using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Vidas : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Image[] hearts;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            hearts[currentHealth].gameObject.SetActive(false);

            if (currentHealth == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                // Aquí puedes agregar cualquier otro código que desees cuando el jugador pierda todas las vidas
            }
        }
    }


}
