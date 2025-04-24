using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;
    public int levels = 1;
    private int prevLevel = 1;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score",score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore() {
    score += 1;

    if (score >= 0 && score < 20) {
        BallController.instance.speed = 5f;
        levels = 1;
    }
    else if (score >= 20 && score < 40) {
        BallController.instance.speed = 6f;
        levels = 2;
    }
    else if (score >= 40 && score < 60) {
        BallController.instance.speed = 7f;
        levels = 3;
    }
    else if (score >= 60 && score < 80) {
        BallController.instance.speed = 8f;
        levels = 4;
    }
    else if (score >= 80 && score < 100) {
        BallController.instance.speed = 9f;
        levels = 5;
    }
    else if (score >= 100 && score < 120) {
        BallController.instance.speed = 10f;
        levels = 6;
    }
    else if (score >= 120 && score < 140) {
        BallController.instance.speed = 11f;
        levels = 7;
    }
    else if (score >= 140 && score < 160) {
        BallController.instance.speed = 12f;
        levels = 8;
    }
    else if (score >= 160 && score < 180) {
        BallController.instance.speed = 13f;
        levels = 9;
    }
    else if (score >= 180) {
        BallController.instance.speed = 14f;
        levels = 10;
    }

    // ✅ Show level only when it changes
    if (levels != prevLevel) {
        UIManager.instance.TriggerLevelDisplay();
        prevLevel = levels;
    }
}


   public void startScore(){
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    public void stopScore(){
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("score",score);

        if(PlayerPrefs.HasKey("highScore")){
            if(score> PlayerPrefs.GetInt("highScore")){
            PlayerPrefs.SetInt("highScore",score);
            }
        }
        else{
            PlayerPrefs.SetInt("highScore",score);
        }
    }
}
