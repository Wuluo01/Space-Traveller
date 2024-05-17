using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApaRetard : MonoBehaviour//para que salgan más tarde
{
    public GameObject objeto;
    public float seconds;
    void Start()
    {
        StartCoroutine(ActivarDespuesDeEspera());
    }
    IEnumerator ActivarDespuesDeEspera()//Para esperar
    {
        yield return new WaitForSeconds(seconds);

        objeto.SetActive(true);
    }
 }
