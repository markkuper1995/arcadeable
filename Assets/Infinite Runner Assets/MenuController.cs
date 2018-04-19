using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject panel;
	public GameManager gameManager;

	public void BackToMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	public void StartGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene("Infinite Runner");
	}

	public void RestartGame(){
		panel.SetActive(false);
		Time.timeScale = 1;
		gameManager.RestartGame();
	}

	public void ResumeGame() {
		Time.timeScale = 1;
		panel.SetActive (false);
	}

	public void PauseGame() {
		Time.timeScale = 0;
		panel.SetActive (true);
	}
}
