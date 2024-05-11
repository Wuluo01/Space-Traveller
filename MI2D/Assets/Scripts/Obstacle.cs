using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    private GameObject escudo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        escudo = GameObject.FindGameObjectWithTag("Escudo");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bordes")
        {
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            if (escudo != null && escudo.activeSelf)
            {
                Destroy(this.gameObject);
                escudo.SetActive(false);
            }
            else
            {
                Destroy(player.gameObject);
            }
        }     
    }
   
}
