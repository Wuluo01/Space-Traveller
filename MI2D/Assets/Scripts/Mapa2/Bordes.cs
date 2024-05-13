using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Borders {
    public float supBorder, infBorder, izqBorder, derBorder;
}

public class Bordes : MonoBehaviour
{
    public Borders borders;
    
    // Update is called once per frame
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
