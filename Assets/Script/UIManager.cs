using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    public static float health = 1;
    public static float rockethealth = 1;
    public Image healthbar,rocketbar;

    public GameObject earth,rocket;
    public GameObject splashText;
    public Text ammoText;
    public static float ammonum;

    void Start()
    {
        earth.SetActive(true);
        rocket.SetActive(true);
        health = 1;
        rockethealth = 1;
        score = 0;
        StartCoroutine(ShowSplashText());

        PlayerPrefs.GetInt("Highscore", score);
    }

    IEnumerator ShowSplashText()
    {
        splashText.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        splashText.SetActive(false);
    }

    void Update()
    {
        scoreText.text = score.ToString();
        //Change Speed per Score
        if(score == 30)
        {
            MeteorController.moveSpeed = 10f;
        }
        if (score == 40)
        {
            MeteorController.moveSpeed = 11f;
        }
        if (score == 50)
        {
            MeteorController.moveSpeed = 12f;
        }
        if (score == 60)
        {
            MeteorController.moveSpeed = 14f;
        }
        if (score == 80)
        {
            MeteorController.moveSpeed = 15f;
        }
        if (score == 100)
        {
            MeteorController.moveSpeed = 16f;
        }
        if (score == 150)
        {
            MeteorController.moveSpeed = 18f;
        }
        if (score == 200)
        {
            MeteorController.moveSpeed = 22f;
        }

        //Health Bar
        healthbar.fillAmount = health;
        rocketbar.fillAmount = rockethealth;

        if(health <= 0)
        {
            earth.SetActive(false);
            GameOverController.gameovered = true;
        }
        else if(rockethealth <= 0)
        {
            rocket.SetActive(false);
            GameOverController.gameovered = true;
        }

        ammoText.text = ammonum.ToString();
    }

    public void SetHighscore()
    {
        //Set the highscore
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

}
