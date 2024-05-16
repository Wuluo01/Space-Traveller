using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject player;  // Referencia al jugador


    void Start()
    {
        // Destruir el proyectil después de 5 segundos para limpiar la escena
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HealthItem"))
        {
            // Recuperar vida del jugador
            Vidas playerHealth = player.GetComponent<Vidas>();
            if (playerHealth != null)
            {
                playerHealth.health += 1;
            }

            // Destruir el ítem
            Destroy(other.gameObject);

            // Destruir el proyectil
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("BulletEnemy");
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }    
}
