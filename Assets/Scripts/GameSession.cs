using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    //state variables
    [SerializeField] int currentScore = 0;

    //Used to check if theres already a game session going on and if theres already 1 destroy this one
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString(); //Update current score
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;  //If we want to make the game faster or slower
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();  //Add point to score if a block is destroyed
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);           //Destroy the current game session
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;    //Check if autoplay is enabled
    }
}
