using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnear : MonoBehaviour
{
public float initialTimeToSpawn = 5f; // Tiempo inicial entre spawns
    public float minTimeToSpawn = 0.5f;   // Tiempo mínimo entre spawns
    public float decreaseRate = 0.95f;    // Factor de disminución del tiempo entre spawns
    public GameObject[] prefabs;
    public Transform[] spawners;

    private float currentTimeToSpawn;

    IEnumerator Start()
    {
        currentTimeToSpawn = initialTimeToSpawn;

        while (true)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                        spawners[Random.Range(0, spawners.Length)].position,
                        Quaternion.identity);

            yield return new WaitForSeconds(currentTimeToSpawn);

            // Disminuir el tiempo entre spawns
            currentTimeToSpawn *= decreaseRate;
            currentTimeToSpawn = Mathf.Max(currentTimeToSpawn, minTimeToSpawn);
        }
    }
}
