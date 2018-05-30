using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class ScoreManager : MonoBehaviour {
    
    public Text scoreText;
    public Text highscoreText;
    public Text coinText;

    public float scoreCount;
    public float highscoreCount;
    public int coinCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    
	private float[] highscoreArray;
	private int currentCharacter;

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		if (PlayerPrefsX.GetFloatArray ("Highscore", 0, 0).Length != 0) {
			highscoreArray = PlayerPrefsX.GetFloatArray ("Highscore", 0, 0);
			currentCharacter = PlayerPrefs.GetInt ("CurrentCharacter", 0);
			highscoreCount = highscoreArray [currentCharacter];
		} else {
			highscoreArray = new float[3] { 0, 0, 0 };
			currentCharacter = PlayerPrefs.GetInt ("CurrentCharacter", 0);
			highscoreCount = 0;
		}


        coinCount = PlayerPrefs.GetInt("Coins");
	}
	
	// Update is called once per frame
	void Update()
    {
		if (!gameManager.startGame.GetAfterThreeTwoOne())
			return;
		
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
			highscoreArray [currentCharacter] = highscoreCount;
			PlayerPrefsX.SetFloatArray("Highscore", highscoreArray);
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
