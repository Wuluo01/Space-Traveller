using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Guide : MonoBehaviour//para los botones de la guía
{
    public void GuideAHowToPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void GuideAEnemies()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void GuideAItems()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }
}
