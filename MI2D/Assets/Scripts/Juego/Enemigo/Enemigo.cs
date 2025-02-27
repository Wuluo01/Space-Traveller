using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemigo : MonoBehaviour//para el enemigo
{
    public float rotSpeed = 90f;
    Transform player;
    void Update()
    {
        if(player == null)
        {
            GameObject go = GameObject.Find("Nave");
            if (go != null)
            {
                player = go.transform;
            }
        }
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desired = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desired, rotSpeed * Time.deltaTime);
    }  
}
