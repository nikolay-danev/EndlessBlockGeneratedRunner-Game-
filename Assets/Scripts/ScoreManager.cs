using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text bestScoreText;
    public Text goldText;
    public int score = 0;
    public int bestScore;
    public int gold = 0;
    
    public Image GameOverScree;
    public Image StoreImage;

    PlayerController scoring;

    void Start () {
        scoring = GameObject.Find("Player").GetComponent<PlayerController>();
        GameOverScree.gameObject.SetActive(false);
        gold = PlayerPrefs.GetInt("gold");
        bestScore = PlayerPrefs.GetInt("bestScore");       
        bestScoreText.text = "Best score: " + PlayerPrefs.GetString("bestScore", bestScore.ToString());
        goldText.text = "Gold: " + PlayerPrefs.GetString("gold", gold.ToString());
    }

    void Update ()
    {
        if(score > bestScore)
        {
            bestScore = score;           
            PlayerPrefs.SetInt("bestScore", bestScore);
            bestScoreText.text = "Best score: " + bestScore;
        }
		if(scoring.isScoreIncreased == true)
        {
            scoreText.text = "Score: " + score;
        }
        if(scoring.isGoldTouched == true)
        {
            goldText.text = "Gold: " + gold;
        }
    }
    
}
