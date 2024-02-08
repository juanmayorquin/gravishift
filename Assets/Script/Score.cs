using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private void Start()
    {
        scoreText= GetComponent<Text>();

        scoreText.text = "Score: " + GUI.score;
    }
}
