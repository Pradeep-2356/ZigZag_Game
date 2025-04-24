using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Ensure the AudioSource is not null and active
    }

    void Start()
    {
        gameOver = false;

    }

    public void StartGame()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.stopScore();
        gameOver = true;

        BallController.instance.source.Stop();
        BallController.instance.source.gameObject.SetActive(false);
    
}
}
