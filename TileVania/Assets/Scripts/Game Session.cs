using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour
{
    [SerializeField] int intPlayerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;



void Awake()
    {
        int intNumGameSessions = FindObjectsOfType<GameSession>().Length;
        if(intNumGameSessions > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = intPlayerLives.ToString();
        scoreText.text = score.ToString();

    }

    public void ProcessPlayerDeath()
    {
        if(intPlayerLives > 1)
        {
            TakeLife();

        }
        else
        {
            ResetGameSession();

        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    private void TakeLife()
    {
        intPlayerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = intPlayerLives.ToString();
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
