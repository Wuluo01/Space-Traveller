using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour

{
    public GameObject originalBulletPrefab;
    private Rigidbody2D rb;
    public float speed;

    public GameObject newBulletPrefab; // El nuevo prefab de bala
    public float duration = 5f; // Duración del cambio de prefab
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.velocity = new Vector3(
            Random.Range(-1f, 1f),
             Random.Range(-1f, 1f),
              Random.Range(-1f, 1f))
            .normalized * speed;
        rb.angularVelocity = Random.Range(-50f, 50f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            Disparo disparo = other.GetComponent<Disparo>();
            if (disparo != null)
            {
                StartCoroutine(ChangeBulletPrefab(disparo));
            }
            Destroy(gameObject); // Destruye el ítem
        }
    }

    IEnumerator ChangeBulletPrefab(Disparo disparo)
    {
        GameObject BulletPrefab = originalBulletPrefab;
        disparo.bulletPrefab = newBulletPrefab;
        yield return new WaitForSeconds(duration);
        originalBulletPrefab = BulletPrefab;
    }
}
