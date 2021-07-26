using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    private Text scoreText;
    float score = 0;
    private MoveLeft movingScript;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        movingScript = GameObject.Find("Background").GetComponent<MoveLeft>();
    }

    public void OnTriggerEnter(Collider other)
    {
       if (movingScript.dashActive == true)
        {
            score += 2;
        } else
        score++;
        scoreText.text = "Score:" + score;
        Debug.Log(score);
    }
}