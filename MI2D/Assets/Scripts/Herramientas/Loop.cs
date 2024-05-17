using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour//para loopear el fondo
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
