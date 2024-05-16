using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemigo : MonoBehaviour
{
    public float speed;

    void Start()
    {
        // Destruir el proyectil después de 5 segundos para limpiar la escena
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
