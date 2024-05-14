using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameoverImage;
    public static bool gameovered;
    Animator anim;

    void Start()
    {
        gameovered = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameovered)
        {
            anim.SetTrigger("openMenu");
            StartCoroutine(StopTime());
        }
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ReturnGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MobileResetGame()
    {
        SceneManager.LoadScene("MobileMainGame");
    }

    public void MobileReturnGame()
    {
        SceneManager.LoadScene("MobileMainMenu");
    }
}
