using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Disparo : MonoBehaviour//para gestionar lo del disparo del jugador
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    int bulletLayer;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    void Start()
    {
        bulletLayer = gameObject.layer;
    }
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0)
        {    
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
            Bullet bulletScript = bulletGO.GetComponent<Bullet>();
            bulletScript.player = this.gameObject;
        }
    }
}
