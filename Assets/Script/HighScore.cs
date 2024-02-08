using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();

        if (GUI.highScore > 0)
        {
            scoreText.text = "High Score: " + GUI.highScore;
        } else if (GUI.highScore <= 0)
        {
            scoreText.text = "";
        }
    }
}
