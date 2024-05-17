using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VidasEnemigo : MonoBehaviour//para gestionar las vidas de los enemigos
{
    public int health = 1;
    public GameObject Explosion;
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
    void OnTriggerEnter2D(Collider2D other)//gestión de colisiones
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
        {
            health--;
            if (invulnPeriod > 0)
            {
                invulnTimer = invulnPeriod;
                gameObject.layer = 10;
            }
        }
        else { return; }
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
