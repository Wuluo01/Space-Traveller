using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnEnemigo : MonoBehaviour//para espawnear enemigos
{
    public GameObject enemyPrefab;
    public float initialSpawnDistance = 12f;
    public float initialEnemyRate = 5f;  
    public float minEnemyRate = 2f;      
    public float decreaseRate = 0.9f;    
    private float nextEnemy;
    private float currentEnemyRate;
    void Start()
    {
        nextEnemy = initialEnemyRate;
        currentEnemyRate = initialEnemyRate;
    }
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
            currentEnemyRate *= decreaseRate;
            currentEnemyRate = Mathf.Max(currentEnemyRate, minEnemyRate);
        }
    }
}