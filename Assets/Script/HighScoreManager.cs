using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public void SetHighscore()
    {
        //Set the highscore
        if (UIManager.score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", UIManager.score);
        }
    }
}
