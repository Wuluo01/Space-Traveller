using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestruirBullet : MonoBehaviour//para destruir las balas y que no se queden en la escena
{
    public float timer = 3f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
