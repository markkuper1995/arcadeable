using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    
    public Text scoreText;
    public Text highscoreText;
    public Text coinText;

    public float scoreCount;
    public float highscoreCount;
    public int coinCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("Highscore"))
        {
            highscoreCount = PlayerPrefs.GetFloat("Highscore");
        }

        coinCount = PlayerPrefs.GetInt("Coins");
	}
	
	// Update is called once per frame
	void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetFloat("Highscore", highscoreCount);
        }

		scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highscoreText.text = "Highscore: " + Mathf.Round(highscoreCount);
        coinText.text = "Coins: " + coinCount;
        PlayerPrefs.SetInt("Coins", coinCount);
	}

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
    }
}
