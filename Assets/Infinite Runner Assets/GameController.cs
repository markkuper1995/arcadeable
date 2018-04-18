using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject panel;

	public void StartInfiniteRunner() {
		Time.timeScale = 1;
		SceneManager.LoadScene("Infinite Runner", LoadSceneMode.Single);
	}

	public void ReturnToMainMenu() {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}

	public void RestartGame() {
		StartInfiniteRunner();
	}

	public void ResumeGame() {
		panel.SetActive (false);
		Time.timeScale = 1;
	}

	public void PauseGame() {
		panel.SetActive (true);
		Time.timeScale = 0;
	}

	public void Death(){
		Time.timeScale = 0;
		panel.SetActive (true);
	}
}
