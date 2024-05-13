using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnear : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject[] prefabs;
    public Transform[] spawners;
    // Start is called before the first frame update
    IEnumerator Start()

    {
        while (true)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)],
                spawners[Random.Range(0, prefabs.Length)].position,
                Quaternion.identity);
            yield return new WaitForSeconds(timeToSpawn);
        }
        
    }
}
