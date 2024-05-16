using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject[] subAsteroids;
    public int numberOfAsteroids;
    private bool isDestroying;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.velocity = new Vector3(
            Random.Range(-1f,1f),
             Random.Range(-1f, 1f),
              Random.Range(-1f, 1f))
            .normalized * speed;
        rb.angularVelocity = Random.Range(-50f, 50f);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (isDestroying) {
            return;
        }
        if (collision.CompareTag("Bullet"))
        {
            isDestroying = true;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            for(var i = 0; i < numberOfAsteroids; i++)
            {
                Instantiate(
                    subAsteroids[Random.Range(0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                ) ;
            }
        }
        if (collision.CompareTag("Player"))
        {
            isDestroying = true;
            Destroy(this.gameObject);
            for (var i = 0; i < numberOfAsteroids; i++)
            {
                Instantiate(
                    subAsteroids[Random.Range(0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                );
            }
        }
    }
}
