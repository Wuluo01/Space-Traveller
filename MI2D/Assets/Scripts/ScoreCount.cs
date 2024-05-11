using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCount : MonoBehaviour
{
    public Text scoreText;
    private float score;
    public GameObject scoreCount;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 100 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();

        }
        else {
            scoreCount.SetActive(false);          
        }
    }
}
