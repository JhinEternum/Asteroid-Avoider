using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text gameOverText;

    [SerializeField] private GameObject gameOverDisplay;

    [SerializeField] private AsteroidSpawner asteroidSpawner;

    [SerializeField] private ScoreSystem scoreSystem;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        scoreSystem.StopScoring();

        gameOverText.text = $"Score: {scoreSystem.Score()}";

        if (scoreSystem.Score() > PlayerPrefs.GetInt("highestScore"))
        {   
            PlayerPrefs.SetString("username", PersistentData.Instance.currentName);
            PlayerPrefs.SetInt("highestScore", scoreSystem.Score());
            gameOverText.text = $"New King: {PersistentData.Instance.currentName}: {scoreSystem.Score()}";
        }

        gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(MainMenu.GameScene);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(MainMenu.MenuScene);
    }
}
