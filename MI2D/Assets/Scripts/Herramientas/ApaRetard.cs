using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApaRetard : MonoBehaviour
{
    public GameObject objeto;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivarDespuesDeEspera());
    }

    // Update is called once per frame
    IEnumerator ActivarDespuesDeEspera()
    {
        // Esperar 3 segundos
        yield return new WaitForSeconds(seconds);

        // Activar el gameobject
        objeto.SetActive(true);
    }
 }
