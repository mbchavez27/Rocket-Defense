using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void PlayMobile()
    {
        SceneManager.LoadScene("MobileMainGame");
    }

    public void MenuMobile()
    {
        SceneManager.LoadScene("MobileMainMenu");
    }

    public void ReturnGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
