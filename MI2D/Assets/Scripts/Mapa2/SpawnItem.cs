using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject itemPrefab;

    float spawnDistance = 12f;

    float ItemRate = 8;
    float nextItem = 1;

    // Update is called once per frame
    void Update()
    {
        nextItem -= Time.deltaTime;

        if (nextItem <= 0)
        {
            nextItem = ItemRate;
            ItemRate *= 0.95f;
            if (ItemRate < 2)
                ItemRate = 2;

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(itemPrefab, transform.position + offset, Quaternion.identity);
        }
    }

}
