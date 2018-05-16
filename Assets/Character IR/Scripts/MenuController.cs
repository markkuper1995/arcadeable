using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public GameObject panel;
	public GameManager gameManager;
	public Button pauseButton;

	public void BackToMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	public void StartGame(){
		Time.timeScale = 1;
		int currentCharacter = PlayerPrefs.GetInt ("CurrentCharacter" );

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
		Time.timeScale = 1;
		pauseButton.gameObject.SetActive (true);
		gameManager.RestartGame();
	}

	public void ResumeGame() {
		Time.timeScale = 1;
		panel.SetActive (false);
		pauseButton.gameObject.SetActive (true);
	}

	public void PauseGame() {
		Time.timeScale = 0;
		pauseButton.gameObject.SetActive (false);
		panel.SetActive (true);
	}
}
