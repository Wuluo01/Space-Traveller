using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnearEscudo : MonoBehaviour
{
    public GameObject escudoSpawneado;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float initialTimeSpawn;
    public float incrementTime;
    public float currentTimeSpawn;
    public float startTime;
    public float distanceToIncreaseTimeSpawn;
    public float distanceTraveled;

    void Start()
    {
        currentTimeSpawn = initialTimeSpawn;
        startTime = Time.time;
    }

    void Update()
    {
        distanceTraveled += Time.deltaTime * 10f;
        if (Time.time > startTime + currentTimeSpawn)
        {
            Spawn();
            startTime = Time.time;
        }

        if (distanceTraveled >= distanceToIncreaseTimeSpawn)
        {
            currentTimeSpawn -= incrementTime; 
            distanceTraveled = 0; // Reiniciar la distancia recorrida
        }
    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(escudoSpawneado, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
