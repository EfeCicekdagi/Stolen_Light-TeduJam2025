using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject gameOverText; 
    public GameObject spaceToStartText;
    public GameObject deathImage; 
    public Health playerHealth;
    public SceneLoader sceneLoader; 

    void Start()
    {
        blackScreen.SetActive(false); 
        gameOverText.SetActive(false); 
        spaceToStartText.SetActive(false);
        deathImage.SetActive(false); 
    }

    void Update()
    {
        if (playerHealth.GetHealth() <= 0)
        {
            ShowGameOver();
        }
        if (blackScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            GoToStartMenu();
        }
    }
    public void ShowGameOver()
    {
        blackScreen.SetActive(true);
        gameOverText.SetActive(true); 
        spaceToStartText.SetActive(true); 
        deathImage.SetActive(true); 
        Time.timeScale = 0f; 
    }
    public void GoToStartMenu()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadStartScreen();
    }
}