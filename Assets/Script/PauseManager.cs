using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public Button pauseButton;
    public Sprite pausebutton, playbutton;
    public GameObject pausedText,pausedbuttons;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        if(Time.timeScale == 1 && !GameOverController.gameovered)
        {
            pauseButton.GetComponent<Image>().sprite = pausebutton;
            pausedText.SetActive(false);
            pausedbuttons.SetActive(false);
        }
        if (Time.timeScale == 0 && !GameOverController.gameovered)
        {
            pauseButton.GetComponent<Image>().sprite = playbutton;
            pausedText.SetActive(true);
            pausedbuttons.SetActive(true);
        }
    }

    public void PausePlayGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MobileResetGame()
    {
        SceneManager.LoadScene("MobileMainGame");
    }

    public void MobileReturnGame()
    {
        SceneManager.LoadScene("MobileMainMenu");
    }



    public void ReturnGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
