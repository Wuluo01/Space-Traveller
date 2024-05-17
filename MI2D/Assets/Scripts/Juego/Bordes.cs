using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Borders {
    public float supBorder, infBorder, izqBorder, derBorder;
}
public class Bordes : MonoBehaviour//para los bordes, que pueda ir a un lado y salir por el otro lado de la pantalla
{
    public Borders borders;
    void Update()
    {
        var pos = transform.position;
        var x = transform.position.x;
        var y = transform.position.y;
        if(x > borders.derBorder)
        {
            pos.x = borders.izqBorder;
            transform.position = pos;
        }
        if (x < borders.izqBorder)
        {
            pos.x = borders.derBorder;
            transform.position = pos;
        }
        if (y > borders.supBorder)
        {
            pos.y = borders.infBorder;
            transform.position = pos;
        }
        if (y < borders.infBorder)
        {
            pos.y = borders.supBorder;
            transform.position = pos;
        }
    }
}
