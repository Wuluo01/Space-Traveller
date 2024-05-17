using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Vidas : MonoBehaviour//para todas las interacciones con la vida del jugador
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
    void OnTriggerEnter2D(Collider2D other)//gestión de choque con enemigos, balas,items
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
            health += 1;
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
    void Update()//gestión de la vida
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
    void Die()//muere
    {
        PlayExplosion();
        Destroy(gameObject);
    }
    void PlayExplosion()//explota
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
