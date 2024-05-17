using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawnear : MonoBehaviour//para spawnear los asteroides y aumente la velocidad de spawneo
{
    public float initialTimeToSpawn = 5f; 
    public float minTimeToSpawn = 0.5f;  
    public float decreaseRate = 0.95f;    
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
            currentTimeToSpawn *= decreaseRate;
            currentTimeToSpawn = Mathf.Max(currentTimeToSpawn, minTimeToSpawn);
        }
    }
}
