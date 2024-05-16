using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasEnemigo : MonoBehaviour
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
