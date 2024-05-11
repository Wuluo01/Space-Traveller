using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private GameObject escudo;
    // Start is called before the first frame update   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bordes")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            escudo = GameObject.FindGameObjectWithTag("Escudo");
            if (escudo != null && !escudo.activeSelf)
            {
                escudo.SetActive(true);
            }
        }
    }
}
