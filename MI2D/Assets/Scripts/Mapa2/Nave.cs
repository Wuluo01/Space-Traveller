using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float drag;
    public float angularSpeed;
    public float shootRate = 0.5f;
    public float offsetBullet;
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    private float vertical;
    private float horizontal;
    private bool shooting;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }

    void Update()
    {
        vertical = InputManager.Vertical;
        horizontal = InputManager.Horizontal;
        shooting = InputManager.Fire;
        Rotate();
        Shoot();
    }

    void FixedUpdate()
    {
        var forwardMotor = Mathf.Clamp(vertical, 0f, 1f);
        rb.AddForce(transform.up * acceleration * forwardMotor);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Rotate()
    {
        if (horizontal == 0)
        {
            return;
        }
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);
    }

    private void Shoot()
    {

        if (shooting && canShoot)
        {
            StartCoroutine(FireRate());
        }
    }
    private IEnumerator FireRate()
    {
        canShoot = false;
        var pos = transform.up * offsetBullet + transform.position;
        var bullet = Instantiate(
            bulletPrefab, pos, transform.rotation
            );

        Destroy(bullet, 5);
        yield return new WaitForSeconds(shootRate);
        canShoot = true;
    }
}
