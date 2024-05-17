using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Backs : MonoBehaviour//para los botones
{
    public void GuideAMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void HowToPlayAGuide()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void EnemiesAGuide()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void ItemsAGuide()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }
    public void SettingsAMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void CreditosAMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void MapasAMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
    }
}
