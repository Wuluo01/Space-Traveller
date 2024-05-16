using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float initialSpawnDistance = 12f;
    public float initialEnemyRate = 5f;  // Tiempo inicial entre spawns
    public float minEnemyRate = 2f;      // Tiempo mínimo entre spawns
    public float decreaseRate = 0.9f;    // Factor de disminución del tiempo entre spawns

    private float nextEnemy;
    private float currentEnemyRate;

    void Start()
    {
        nextEnemy = initialEnemyRate;
        currentEnemyRate = initialEnemyRate;
    }

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = currentEnemyRate;

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * initialSpawnDistance;

            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);

            // Disminuir el tiempo entre spawns
            currentEnemyRate *= decreaseRate;
            currentEnemyRate = Mathf.Max(currentEnemyRate, minEnemyRate);
        }
    }
}