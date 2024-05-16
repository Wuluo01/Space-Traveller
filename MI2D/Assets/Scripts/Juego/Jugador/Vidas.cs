using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public int health = 1;
    public GameObject Explosion;
    public GameObject HyperExplosion;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        // NOTE!  This only get the renderer on the parent object.
        // In other words, it doesn't work for children. I.E. "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BulletEnemy") || other.gameObject.CompareTag("Enemy"))
        {
            health--;
            if (invulnPeriod > 0)
            {
                invulnTimer = invulnPeriod;
                gameObject.layer = 10;
            }
        }
        else if (other.gameObject.CompareTag("HealthItem"))
        {
            // Recuperar vida del jugador
            health += 1;

            // Destruir el ítem
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            Instantiate(HyperExplosion, other.transform.position, other.transform.rotation);
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
        }       
    }

    void Update()
    {

        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayExplosion();
        Destroy(gameObject);
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
