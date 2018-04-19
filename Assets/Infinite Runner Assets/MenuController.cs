using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject panel;

	public void BackToMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	public void StartGame(){
		SceneManager.LoadScene("Infinite Runner");
	}

	public void RestartGame(){
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		Time.timeScale = 1;
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
