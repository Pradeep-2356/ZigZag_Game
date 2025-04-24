using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject zigzagPanel;
    public GameObject LevelsPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text dispScore;
    public Text Levels;
    public Text highScore1;
    public Text highScore2;
    public GameObject particle;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver(){
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset(){
        SceneManager.LoadScene(0);
    }
    void ScoreDisp(){
        dispScore.text = ScoreManager.instance.score.ToString();
    }
   IEnumerator ShowLevels() {
    Levels.text = ScoreManager.instance.levels.ToString();
    LevelsPanel.gameObject.SetActive(true); // make sure it’s visible
    LevelsPanel.GetComponent<Animator>().Play("LevelFadeOut");
    Instantiate(particle,LevelsPanel.transform.position, Quaternion.identity);
    yield return new WaitForSeconds(3f); // wait for 1 second
    LevelsPanel.gameObject.SetActive(false); // hide the level display
}

public void TriggerLevelDisplay() {
    StopAllCoroutines();
    StartCoroutine(ShowLevels());
}

    // Update is called once per frame
    void Update()
    {
    
        ScoreDisp();
    }
}
