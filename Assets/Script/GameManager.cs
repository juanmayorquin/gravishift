using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text lifes, score;

    // Update is called once per frame
    void Update()
    {
        lifes.text = GUI.lifes.ToString();
        score.text = GUI.score.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameFinished()
    {
        if (GUI.score > GUI.highScore)
        {
            GUI.highScore = GUI.score;
        }
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
