using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour//para el botón de splash y que vaya al menú principal después de 8 segundos si no se toca nada
{
    void Start()
    {
        StartCoroutine(ActivarDespuesDeEspera());
    }
    IEnumerator ActivarDespuesDeEspera()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
