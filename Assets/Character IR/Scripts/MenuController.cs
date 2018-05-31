using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AssemblyCSharp;

public class MenuController : MonoBehaviour {

	public GameObject panel;
	public GameManager gameManager;
	public Button pauseButton;

    private bool continueGame = false;

	public void BackToMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	public void StartIF(){
		int currentCharacter = PlayerPrefs.GetInt ("CurrentCharacter", 0 );

		switch (currentCharacter) {
			case 0: 
				SceneManager.LoadScene("Infinite Runner");
				break;
			case 1:
				SceneManager.LoadScene("Infinite Runner - Zuck");
				break;
			case 2:
				SceneManager.LoadScene("Infinite Runner - Bolt");
				break;
			default:
				SceneManager.LoadScene("Infinite Runner");
				break;
		}
	}

	public void RestartGame(){
		panel.SetActive(false);
		pauseButton.gameObject.SetActive (true);
		gameManager.RestartGame();
        continueGame = false;
	}

	public void ResumeGame() {
		panel.SetActive (false);
		pauseButton.gameObject.SetActive (true);
		gameManager.ResumeGame();
	}

    public void ContinueGame()
    {
        if (continueGame == false)
        {
            continueGame = true;
            panel.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            gameManager.ContinueGame();
        }
    }

	public void PauseGame() {
		Time.timeScale = 0;
		pauseButton.gameObject.SetActive (false);
		panel.SetActive (true);
		gameManager.startGame.SetAfterThreeTwoOne(false);
	}
}
